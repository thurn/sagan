using System;
using UnityEngine;

public class Root : MonoBehaviour
{
    public Camera MainCamera;
    public Canvas MainCanvas;
    public GameObject ControlWindow;
    public GameObject ControlBox;
    public GameObject ControlList;
    public GameObject ProductionItem;
    public GameObject ProgressBar;
    public GameObject Probe;

    public GameObject InstantiatePrefab(GameObject prefab, Transform parent)
    {
        if (parent == null)
        {
            throw new ArgumentNullException("parent");
        }
        return InstantiatePrefabPrivate(prefab, parent);
    }

    public GameObject InstantiatePrefabWithoutParent(GameObject prefab)
    {
        return InstantiatePrefabPrivate(prefab, null);
    }

    public T InstantiatePrefabComponent<T>(GameObject prefab, Transform parent) where T : SaganComponent
    {
        var item = InstantiatePrefab(prefab, parent);
        var result = item.GetComponent<T>();
        if (result == null)
        {
            throw new InvalidOperationException("Prefab " + item + " is missing primary component " + typeof(T));
        }
        return result;
    }

    public T GetService<T>() where T : SaganService
    {
        return GetComponent<T>();
    }

    private GameObject InstantiatePrefabPrivate(GameObject prefab, Transform parent)
    {
        if (prefab == null)
        {
            throw new ArgumentNullException("prefab");
        }

        var item = Instantiate(prefab);
        item.transform.SetParent(parent, false);
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.Root = this;
        }
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.CallOnCreateFromRoot();
        }

        return item;
    }
}