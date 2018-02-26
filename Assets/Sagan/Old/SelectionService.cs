using Sagan.Core;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionService : SaganService
{
    private GameObject _currentlySelected;
    private Camera _camera;
    private EventSystem _eventSystem;
    private ProductionService _productionService;

    private void Start()
    {
        _camera = Root.MainCamera;
        _eventSystem = Root.MainCanvas.GetComponent<EventSystem>();
        _productionService = Root.GetService<ProductionService>();
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
                var unit = objectHit.GetComponent<Unit>();
                if (unit != null)
                {
                    var outline = objectHit.AddComponent<cakeslice.Outline>();
                    outline.color = 1;
                    _currentlySelected = objectHit;
                    if (unit.UnitType.IsProducer())
                    {
                        _productionService.ShowProductionWindowForProducer(unit);
                    }
                    else
                    {
                    }
                }
            }
            else if (!_eventSystem.IsPointerOverGameObject())
            {
                _productionService.HideProductionWindow();
                if (_currentlySelected)
                {
                    Destroy(_currentlySelected.GetComponent<cakeslice.Outline>());
                }
                _currentlySelected = null;
            }
        }
    }
}