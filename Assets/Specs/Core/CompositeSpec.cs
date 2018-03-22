using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Specs.Generated.Resources;
using Specs.Util;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using Object = UnityEngine.Object;

namespace Specs.Core
{
  public class CompositeSpec : Spec<GameObject>
  {
    private readonly string _name;
    private readonly ITransformSpec _transform;
    private readonly IImmutableList<Spec> _children;
    private string _structuralHash;

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

    public void LoadRoot(Res res, GameObject parent, bool reuseFromCache = false)
    {
      Errors.CheckNotNull(res, nameof(res));
      Errors.CheckNotNull(parent, nameof(parent));

      var previousInstance = parent.transform.Find(_name);
      if (previousInstance != null && !reuseFromCache)
      {
        Object.Destroy(previousInstance.gameObject);
      }

      var result = Mount(res, parent, reuseFromCache: reuseFromCache);

      if (Errors.IsNullOrUnityNull(result))
      {
        throw Errors.MountFailed(parent.name, Name);
      }
    }

    public string GetStructuralHash()
    {
      if (_structuralHash == null)
      {
        var childBytes = new LinkedList<byte[]>();
        AddChildHashes(childBytes);
        var bytes = childBytes.SelectMany(selector: i => i).ToArray();
        var hashstring = new SHA256Managed();
        var hashed = hashstring.ComputeHash(bytes);
        _structuralHash = Convert.ToBase64String(hashed);
      }

      return _structuralHash;
    }

    public sealed override void AddChildHashes(LinkedList<byte[]> children)
    {
      children.AddLast(Encoding.UTF8.GetBytes(Name));
      foreach (var child in _children)
      {
        child.AddChildHashes(children);
      }
    }

    protected sealed override GameObject Mount(Res res, GameObject parent, bool reuseFromCache)
    {
      GameObject gameObject;
      if (reuseFromCache)
      {
        var transform = parent.transform.Find(_name);
        if (transform == null)
        {
          throw Errors.ChildNotFound(parent.name, _name);
        }

        gameObject = transform.gameObject;
      }
      else
      {
        gameObject = new GameObject(_name);
        gameObject.layer = 5;
        var transform = _transform.MountTransform(res, gameObject);
        transform.SetParent(parent.transform, worldPositionStays: false);
      }

      foreach (var child in _children)
      {
        child.MountInternal(res, gameObject, reuseFromCache);
      }

      foreach (var child in _children)
      {
        child.UpdateInternal(res, gameObject);
      }

      _transform.UpdateTransform(res, gameObject.transform);

      return gameObject;
    }

    protected sealed override void Update(Res res, GameObject instance)
    {
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