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

  public abstract class Spec<T> : ISpec
  {
    public abstract T Mount(Res res, GameObject parent);
 
    public abstract T GetInstance(GameObject parent);

    public abstract void Update(Res res, T instance);

    public void MountSpec(Res res, GameObject parent)
    {
      Requires.NotNull(res, nameof(res));
      Requires.NotNull(parent, nameof(parent));
      var result = Mount(res, parent);

      if (result == null)
      {
        throw Errors.MountFailed(parent.name, GetType().Name);
      }
    }

    public void UpdateSpec(Res res, GameObject parent)
    {
      Requires.NotNull(res, nameof(res));
      Requires.NotNull(parent, nameof(parent));
      var instance = GetInstance(parent);

      if (instance == null)
      {
        throw Errors.InstanceNotFound(parent.name, GetType().Name);
      }

      Update(res, instance);
    }

    public static ImmutableList<ISpec> SpecList(params ISpec[] children) =>
      ImmutableList.CreateRange(children);
  }
}