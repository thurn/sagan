using System;
using System.Collections.Immutable;
using Specs.Generated;
using Specs.Util;
using UnityEngine;

namespace Specs.Core
{
  public class CompositeSpec: Spec<GameObject>
  {
    private readonly string _name;
    private readonly ITransformSpec _transform;
    private readonly IImmutableList<Spec> _children;

    public override string Name => _name;
 
    public CompositeSpec(
      string name,
      ITransformSpec transform,
      IImmutableList<Spec> children,
      string specId = "")
    {
      _name = ValidateName(name) + ValidateName(specId);
      _transform = Errors.CheckNotNullPassthrough(transform, nameof(transform));
      _children = Errors.CheckNotNullPassthrough(children, nameof(children));
    }
 
    public GameObject LoadRoot(Res res, GameObject parent)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));

      var childTransform = parent.transform.Find(_name);
      if (childTransform != null)
      {
        childTransform.gameObject.SetActive(value: false);
      }
 
      var result = Mount(res, parent);
 
      if (Errors.IsNullOrUnityNull(result))
      {
        throw Errors.MountFailed(parent.name, Name);
      }
 
      return result;
    }

    protected sealed override GameObject Mount(Res res, GameObject parent)
    {
      GameObject gameObject;
      var childTransform = parent.transform.Find(_name);

      if (childTransform == null)
      {
        gameObject = new GameObject(_name);
        var transform = _transform.MountTransform(res, gameObject);
        transform.SetParent(parent.transform, worldPositionStays: false);
      }
      else if (childTransform.gameObject.activeSelf)
      {
        throw Errors.DuplicateChild(parent.name, _name);
      }
      else
      {
        gameObject = childTransform.gameObject;
        gameObject.SetActive(value: true);
        DeactivateChildren(gameObject);
      }

      _transform.UpdateTransform(res, gameObject.transform);

      foreach (var child in _children)
      {
        child.MountInternal(res, gameObject);
      }

      foreach (var child in _children)
      {
        child.UpdateInternal(res, gameObject);
      }
 
      return gameObject;
    }

    protected sealed override void Update(Res res, GameObject instance)
    {

    }

    private static void DeactivateChildren(GameObject parent)
    {
      foreach (Transform transform in parent.transform)
      {
        transform.gameObject.SetActive(value: false);
      }

      foreach (var behaviour in parent.GetComponents<Behaviour>())
      {
        behaviour.enabled = false;
      }
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