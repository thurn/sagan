using UnityEngine;
using UnityEngine.UI;

public class ProductionItemList : MonoBehaviour {
    [SerializeField] private VerticalLayoutGroup _productionItemGroup;
    [SerializeField] private ProductionItem _productionItemPrefab;

    public void AddProductionItem(string text)
    {
        var item = Instantiate(_productionItemPrefab);
        item.transform.SetParent(_productionItemGroup.transform, false);
        item.SetContent(text);
    }
}
