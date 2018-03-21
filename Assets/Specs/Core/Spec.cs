using System.Collections.Generic;
using System.Collections.Immutable;
using Specs.Generated.Resources;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public abstract class Spec
  {
    public static IImmutableList<Spec> List(params Spec[] items) =>
      ImmutableArray.CreateRange(items);

    public abstract void MountInternal(Res res, GameObject parent, bool reuseFromCache);

    public abstract void UpdateInternal(Res res, GameObject parent);

    public abstract void AddChildHashes(LinkedList<byte[]> children);

    public abstract string Name { get; }
  }

  public abstract class Spec<T> : Spec where T : class
  {
    public sealed override void MountInternal(Res res, GameObject parent, bool reuseFromCache)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      var result = Mount(res, parent, reuseFromCache);

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

    public override string Name => GetType().Name;

    protected abstract T Mount(Res res, GameObject parent, bool reuseFromCache);

    protected abstract void Update(Res res, GameObject parent);
  }
}