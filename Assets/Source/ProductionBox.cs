using UnityEngine;
using UnityEngine.UI;

public class ProductionBox : SaganComponent {
    private GameObject _productionList;

    public override void OnCreate()
    {
        _productionList = Root.InstantiatePrefab(Root.ProductionList, transform);
    }

    public void AddProductionItem(Item item)
    {
        var itemObject = Root.InstantiatePrefab(Root.ProductionItem, _productionList.transform);
        var itemComponent = itemObject.GetComponent<ProductionItem>();
        itemComponent.SetContent(item);
    }
}
