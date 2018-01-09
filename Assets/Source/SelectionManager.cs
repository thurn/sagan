using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : SaganService {
    private UIWindow _controlWindow;
    private GameObject _currentlySelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentlySelected)
            {
                Destroy(_currentlySelected.GetComponent<cakeslice.Outline>());
            }
            _currentlySelected = null;

            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var objectHit = hit.transform.gameObject;
                if (objectHit.tag.Equals("Selectable"))
                {
                    var outline = objectHit.AddComponent<cakeslice.Outline>();
                    outline.color = 1;
                    _currentlySelected = objectHit;
                    ShowProductionWindow(_currentlySelected);
                }
            }

            if (_currentlySelected != null && _controlWindow != null)
            {
                _controlWindow.Show();
            }
            else if (_controlWindow != null)
            {
                _controlWindow.Hide();
            }
        }
    }

    private void ShowProductionWindow(GameObject selected)
    {
        if (!_controlWindow)
        {
            var window = Root.InstantiatePrefab(Root.ControlWindow, Root.MainCanvas.transform);
            _controlWindow = window.GetComponent<UIWindow>();
            var productionBox = Root.InstantiatePrefab(Root.ProductionBox, _controlWindow.transform);
            AddProductionOptions(productionBox.GetComponent<ProductionBox>(), selected);
        }
    }

    private void AddProductionOptions(ProductionBox productionItemList, GameObject selected)
    {
        productionItemList.AddProductionItem("Probe");
        productionItemList.AddProductionItem("Extractor");
        productionItemList.AddProductionItem("Launch System");
        productionItemList.AddProductionItem("Autofactory");
    }
}
