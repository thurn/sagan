using System.Collections.Generic;
using System.Collections.Immutable;
using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public interface ISpec
  {
    void PerformMount(Res res, GameObject parent);
 
    void PerformUpdate(Res res, GameObject parent);

    string Name { get; }

    bool Composite { get; }
  }

  public class Spec
  {
    public static IImmutableList<T> List<T>(params T[] items) =>
      ImmutableArray.CreateRange(items);

  }

  public abstract class Spec<T> : ISpec where T : class
  {
    public virtual string Name => GetType().Name;

    public virtual bool Composite => false;
 
    // TODO: move caching to a separate coordinator object
    private readonly Dictionary<GameObject, T> _instanceCache = new Dictionary<GameObject,T>();

    protected abstract T Mount(Res res, GameObject parent);

    protected abstract T GetInstance(GameObject parent);

    protected abstract void Update(Res res, T instance);
 
    public void PerformMount(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var result = Mount(res, parent);

      if (Errors.IsNullOrUnityNull(result))
      {
        throw Errors.MountFailed(parent.name, Name);
      }
    }
 
    public void PerformUpdate(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var instance = GetSpecInstance(parent);

      if (Errors.IsNullOrUnityNull(instance))
      {
        throw Errors.InstanceNotFound(parent.name, Name);
      }

      Update(res, instance);
    }

    public static IImmutableList<ISpec> SpecList(params ISpec[] children) =>
      ImmutableArray.CreateRange(children);
 
    public static IImmutableList<ISpec> SpecList(IEnumerable<ISpec> children) =>
      ImmutableArray.CreateRange(children);
 
    private T GetSpecInstance(GameObject parent)
    {
      if (_instanceCache.ContainsKey(parent))
      {
        return _instanceCache[parent];
      }

      var instance = GetInstance(parent);
      _instanceCache[parent] = instance;
      return instance;
    }
  }
}