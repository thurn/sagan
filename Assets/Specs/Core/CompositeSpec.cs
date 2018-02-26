using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Specs.Generated;
using Specs.Util;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Specs.Core
{
  public class CompositeSpec: Spec<GameObject>
  {
    private readonly string _name;
    private readonly ITransformSpec _transform;
    private readonly IImmutableList<ISpec> _children;
 
    public override string Name => _name;

    public CompositeSpec(
      string name,
      ITransformSpec transform,
      IImmutableList<ISpec> children = null,
      string specId = "")
    {
      _name = ValidateName(name) + ValidateName(specId);
      _transform = Errors.CheckNotNullPassthrough(transform, nameof(transform));
      _children = children ?? ImmutableArray<ISpec>.Empty;
    }
 
    public sealed override GameObject Mount(Res res, GameObject parent)
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
        child.MountSpec(res, gameObject);
      }

      foreach (var child in _children)
      {
        child.UpdateSpec(res, gameObject);
      }

      Debug.Log("Updating transform for " + Name);
      _transform.UpdateTransform(res, transform);

      return gameObject;
    }
 
    public sealed override GameObject GetInstance(GameObject parent)
    {
      var transform = parent.transform.Find(_name);

      if (Errors.IsNullOrUnityNull(transform) || Errors.IsNullOrUnityNull(transform.gameObject))
      {
        throw Errors.InstanceNotFound(parent.name, _name);
      }

      return transform.gameObject;
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
  
    public sealed override void Update(Res res, GameObject instance)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(instance, nameof(instance));

      foreach (var child in _children)
      {
        child.UpdateSpec(res, instance);
      }
    }
  }
}