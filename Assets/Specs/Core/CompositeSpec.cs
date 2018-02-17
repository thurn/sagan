using System.Collections.Generic;
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
    private readonly ImmutableList<ISpec> _children;
    private readonly Dictionary<GameObject, GameObject> _gameObjectCache =
      new Dictionary<GameObject, GameObject>();
 
    public CompositeSpec(
      string name,
      ITransformSpec transform,
      IEnumerable<ISpec> children = null)
    {
      _name = Requires.NotNullPassthrough(name, nameof(name));
      _transform = Requires.NotNullPassthrough(transform, nameof(transform));
      _children = ImmutableList.CreateRange(children) ?? ImmutableList<ISpec>.Empty;
    }
 
    public sealed override GameObject Mount(Res res, GameObject parent)
    {
      Requires.NotNull(res, nameof(res));
      Requires.NotNull(parent, nameof(parent));

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

      // We update the transform last because e.g. LayoutGroups can modify its behavior
      _transform.UpdateTransform(res, transform);

      _gameObjectCache[parent] = gameObject;
      return gameObject;
    }
 
    public sealed override GameObject GetInstance(GameObject parent)
    {
      Requires.NotNull(parent, nameof(parent));
      if (!_gameObjectCache.ContainsKey(parent))
      {
        throw Errors.ParentNotInCache(parent.name, _name);
      }

      return _gameObjectCache[parent];
    }
  
    public sealed override void Update(Res res, GameObject instance)
    {
      Requires.NotNull(res, nameof(res));
      Requires.NotNull(instance, nameof(instance));

      foreach (var child in _children)
      {
        child.UpdateSpec(res, instance);
      }
    }
  }
}