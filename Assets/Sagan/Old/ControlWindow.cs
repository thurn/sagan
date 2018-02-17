using System.Collections.Generic;
using UnityEngine;

public class ControlWindow : SaganComponent
{
    private List<SaganComponent> _children = new List<SaganComponent>();

    public T AddChildPrefab<T>(GameObject prefab) where T : SaganComponent
    {
        var component = Root.InstantiatePrefabComponent<T>(prefab, transform);
        _children.Add(component);
        return component;
    }

    public void RemoveChildren()
    {
        foreach (var child in _children)
        {
            Destroy(child.gameObject);
        }
        _children = new List<SaganComponent>();
    }
}