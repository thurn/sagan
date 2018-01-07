using UnityEngine;
using UnityEngine.UI;

public class ProductionBox : SaganComponent {
    private GameObject _productionList;

    public override void OnCreate()
    {
        _productionList = Root.InstantiatePrefab(Root.ProductionList, transform);
    }

    public void AddProductionItem(string text)
    {
        var itemObject = Root.InstantiatePrefab(Root.ProductionItem, _productionList.transform);
        var item = itemObject.GetComponent<ProductionItem>();
        item.SetContent(text);
    }
}
