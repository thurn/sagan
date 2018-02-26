using System.Collections.Generic;
using System.Collections.Immutable;
using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public interface ISpec
  {
    void MountSpec(Res res, GameObject parent);
 
    void UpdateSpec(Res res, GameObject parent);
  }

  public class Spec
  {
    public static IImmutableList<T> List<T>(params T[] items) =>
      ImmutableArray.CreateRange(items);

  }

  public abstract class Spec<T> : ISpec where T : class
  {
    public virtual string Name => GetType().Name;

    private readonly Dictionary<GameObject, T> _instanceCache = new Dictionary<GameObject,T>();

    public abstract T Mount(Res res, GameObject parent);
 
    public abstract T GetInstance(GameObject parent);

    public abstract void Update(Res res, T instance);

    public T GetSpecInstance(GameObject parent)
    {
      if (_instanceCache.ContainsKey(parent))
      {
        return _instanceCache[parent];
      }

      var instance = GetInstance(parent);
      _instanceCache[parent] = instance;
      return instance;
    }
 
    public void MountSpec(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var result = Mount(res, parent);

      if (Errors.IsNullOrUnityNull(result))
      {
        throw Errors.MountFailed(parent.name, Name);
      }
    }
 
    public void UpdateSpec(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var instance = GetSpecInstance(parent);

      if (Errors.IsNullOrUnityNull(instance))
      {
        throw Errors.InstanceNotFound(parent.name, Name);
      }

      Debug.Log("Updating " + Name);
      Update(res, instance);
    }

    public static IImmutableList<ISpec> SpecList(params ISpec[] children) =>
      ImmutableArray.CreateRange(children);
  }
}