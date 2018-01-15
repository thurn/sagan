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

    public T InstantiatePrefabComponent<T>(GameObject prefab, Transform parent) where T : SaganComponent
    {
        if (prefab == null)
        {
            throw new ArgumentNullException("prefab");
        }
        if (parent == null)
        {
            throw new ArgumentNullException("parent");
        }

        var item = Instantiate(prefab);
        item.transform.SetParent(parent, false);
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.SetRootFromRoot(this);
        }
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.CallOnCreateFromRoot();
        }

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
}