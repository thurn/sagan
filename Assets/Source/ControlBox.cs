using UnityEngine;
using UnityEngine.UI;

public class ControlBox : SaganComponent
{
    private Text _title;
    private ControlList _controlList;

    protected override void OnCreate()
    {
        _title = GetComponentInChildren<Text>();
        _controlList = Root.InstantiatePrefabComponent<ControlList>(Root.ControlList, transform);
    }

    public T AddChildPrefab<T>(GameObject prefab) where T : SaganComponent
    {
        return Root.InstantiatePrefabComponent<T>(prefab, _controlList.transform);
    }

    public void SetTitle(string title)
    {
        _title.text = title;
    }
}