﻿using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionService : SaganService
{
    private GameObject _controlWindow;
    private GameObject _currentlySelected;
    private Camera _camera;
    private EventSystem _eventSystem;

    private void Start()
    {
        _camera = Root.MainCamera;
        _eventSystem = Root.MainCanvas.GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

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
            else if (_controlWindow && !_eventSystem.IsPointerOverGameObject())
            {
                _controlWindow.SetActive(false);
                if (_currentlySelected)
                {
                    Destroy(_currentlySelected.GetComponent<cakeslice.Outline>());
                }
                _currentlySelected = null;
            }
        }
    }

    private void ShowProductionWindow(GameObject selected)
    {
        if (!_controlWindow)
        {
            _controlWindow = Root.InstantiatePrefab(Root.ControlWindow, Root.MainCanvas.transform);
            var productionBox = Root.InstantiatePrefab(Root.ProductionBox, _controlWindow.transform);
            AddProductionOptions(productionBox.GetComponent<ProductionBox>(), selected);
        }
        _controlWindow.SetActive(true);
    }

    private void AddProductionOptions(ProductionBox productionItemList, GameObject selected)
    {
        productionItemList.AddProductionItem(Item.Probe);
        productionItemList.AddProductionItem(Item.Extractor);
        productionItemList.AddProductionItem(Item.LaunchSystem);
        productionItemList.AddProductionItem(Item.Autofactory);
    }
}