using System;
using System.Collections.Generic;
using UnityEngine;

public enum Building
{
    Autofactory
}

public class ProductionService : SaganService
{
    private ControlWindow _productionWindow;
    private Unit _currentProducer;

    public void StartProduction(UnitType item)
    {
        StartCoroutine(StartProductionAsync(item));
    }

    private IEnumerator<WaitForSeconds> StartProductionAsync(UnitType item)
    {
        _productionWindow.RemoveChildren();
        ShowConstructionProgress(item);

        yield return new WaitForSeconds(item.GetProductionTimeSeconds());

        var production = Root.InstantiatePrefabWithoutParent(GetPrefabForItem(item));
        production.transform.position = _currentProducer.transform.position + new Vector3(2, 2, 2);
        _productionWindow.RemoveChildren();
        ShowProductionWindowForProducer(_currentProducer);
    }

    public void ShowProductionWindowForProducer(Unit producer)
    {
        if (_productionWindow == null)
        {
            _productionWindow = Root.InstantiatePrefabComponent<ControlWindow>(Root.ControlWindow, Root.MainCanvas.transform);
        }

        _currentProducer = producer;
        _productionWindow.gameObject.SetActive(true);
        ShowProductionOptions();
    }

    public void HideProductionWindow()
    {
        if (_productionWindow != null)
        {
            _productionWindow.gameObject.SetActive(false);
            _productionWindow.RemoveChildren();
        }
        _currentProducer = null;
    }

    private void ShowConstructionProgress(UnitType item)
    {
        var progressBox = _productionWindow.AddChildPrefab<ControlBox>(Root.ControlBox);
        progressBox.SetTitle("PRODUCING");
        var progressBar = progressBox.AddChildPrefab<ProgressBar>(Root.ProgressBar);
        progressBar.SetContent(item.GetName(), item.GetProductionTimeSeconds());
    }

    private void ShowProductionOptions()
    {
        var productionBox = _productionWindow.AddChildPrefab<ControlBox>(Root.ControlBox);
        productionBox.SetTitle("CHOOSE PRODUCTION");
        var items = new List<UnitType> { UnitType.Probe, UnitType.Extractor, UnitType.LaunchSystem, UnitType.Autofactory };

        foreach (var item in items)
        {
            var itemComponent = productionBox.AddChildPrefab<ProductionItem>(Root.ProductionItem);
            itemComponent.SetItem(item);
        }
    }

    private GameObject GetPrefabForItem(UnitType item)
    {
        switch (item)
        {
            case UnitType.Probe:
                return Root.Probe;

            case UnitType.Extractor:
                return Root.Extractor;
        }
        throw new InvalidOperationException("Unknown item " + item);
    }
}