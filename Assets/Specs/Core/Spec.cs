using System.Collections.Generic;
using System.Collections.Immutable;
using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public abstract class Spec
  {
    public static IImmutableList<T> List<T>(params T[] items) =>
      ImmutableArray.CreateRange(items);

    public abstract void MountInternal(Res res, GameObject parent);

    public abstract void UpdateInternal(Res res, GameObject parent);

    public abstract string Name { get; }
  }

  public abstract class Spec<T> : Spec where T : class
  {
    public sealed override void MountInternal(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var result = Mount(res, parent);

      if (Errors.IsNullOrUnityNull(result))
      {
        throw Errors.MountFailed(parent.name, Name);
      }
    }

    public sealed override void UpdateInternal(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      Update(res, parent);
    }
 
    public static IImmutableList<Spec> SpecList(params Spec[] children) =>
      ImmutableArray.CreateRange(children);

    public static IImmutableList<Spec> SpecList(IEnumerable<Spec> children) =>
      ImmutableArray.CreateRange(children);

    public override string Name => GetType().Name;

    protected abstract T Mount(Res res, GameObject parent);

    protected abstract void Update(Res res, GameObject parent);
  }
}