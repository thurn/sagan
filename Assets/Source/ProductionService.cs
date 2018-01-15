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
    private Producer _currentProducer;

    public void StartProduction(Item item)
    {
        StartCoroutine(StartProductionAsync(item));
    }

    private IEnumerator<WaitForSeconds> StartProductionAsync(Item item)
    {
        _productionWindow.RemoveChildren();
        ShowConstructionProgress(item);

        yield return new WaitForSeconds(item.GetProductionTimeSeconds());

        var production = Root.InstantiatePrefabWithoutParent(GetPrefabForItem(item));
        production.transform.position = _currentProducer.transform.position + new Vector3(2, 2, 2);
    }

    public void ShowProductionWindowForProducer(Producer producer)
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
        }
        _currentProducer = null;
    }

    private void ShowConstructionProgress(Item item)
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
        var items = new List<Item> { Item.Probe, Item.Extractor, Item.LaunchSystem, Item.Autofactory };

        foreach (var item in items)
        {
            var itemComponent = productionBox.AddChildPrefab<ProductionItem>(Root.ProductionItem);
            itemComponent.SetItem(item);
        }
    }

    private GameObject GetPrefabForItem(Item item)
    {
        switch (item)
        {
            case Item.Probe:
                return Root.Probe;
        }
        throw new InvalidOperationException("Unknown item " + item);
    }
}