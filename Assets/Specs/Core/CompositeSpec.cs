using System.Collections.Immutable;
using System.Linq;
using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public class CompositeSpec: Spec<GameObject>
  {
    private readonly string _name;
    private readonly ITransformSpec _transform;
    private readonly IImmutableList<ISpec> _components;
    private readonly IImmutableList<ISpec> _children;

    public override string Name => _name;

    public sealed override bool Composite => true;
 
    public CompositeSpec(
      string name,
      ITransformSpec transform,
      IImmutableList<ISpec> children,
      string specId = "")
    {
      _name = ValidateName(name) + ValidateName(specId);
      _transform = Errors.CheckNotNullPassthrough(transform, nameof(transform));
      _components = SpecList(from child in children where !child.Composite select child);
      _children = SpecList(from child in children where child.Composite select child);
    }

    public GameObject MountRoot(Res res, GameObject parent) => Mount(res, parent);

    protected sealed override GameObject Mount(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));
      if (parent.transform.Find(_name))
      {
        throw Errors.DuplicateChild(parent.name, _name);
      }

      var gameObject = new GameObject(_name);
      var transform = _transform.MountTransform(res, gameObject);
      transform.SetParent(parent.transform, worldPositionStays: false);

      foreach (var child in _children)
      {
        child.PerformMount(res, gameObject);
      }

      foreach (var child in _components)
      {
        child.PerformMount(res, gameObject);
      }

      return gameObject;
    }
 
    protected sealed override GameObject GetInstance(GameObject parent)
    {
      var transform = parent.transform.Find(_name);

      if (Errors.IsNullOrUnityNull(transform) || Errors.IsNullOrUnityNull(transform.gameObject))
      {
        throw Errors.InstanceNotFound(parent.name, _name);
      }

      return transform.gameObject;
    }

    protected sealed override void Update(Res res, GameObject instance)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(instance, nameof(instance));

      foreach (var child in _children)
      {
        child.PerformUpdate(res, instance);
      }

      foreach (var child in _components)
      {
        child.PerformUpdate(res, instance);
      }

      var transform = _transform.GetTransformInstance(instance);
      _transform.UpdateTransform(res, transform);
    }

    private string ValidateName(string name)
    {
      Errors.CheckNotNull(name, nameof(name));

      if (name.Contains(value: "/"))
      {
        throw Errors.InvalidName(name);
      }

      return name;
    }
  }
}