using UnityEngine;

public class Root : MonoBehaviour
{
    public Camera MainCamera;
    public Canvas MainCanvas;
    public GameObject ControlWindow;
    public GameObject ProductionBox;
    public GameObject ProductionList;
    public GameObject ProductionItem;

    public GameObject InstantiatePrefab(GameObject prefab, Transform parent)
    {
        var item = Instantiate(prefab);
        item.transform.SetParent(parent, false);
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.SetRoot(this);
        }
        foreach (var component in item.GetComponentsInChildren<SaganComponent>())
        {
            component.OnCreate();
        }
        return item;
    }

    public T GetService<T>() where T : SaganService
    {
        return GetComponent<T>();
    }
}