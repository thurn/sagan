using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour {

    public UIWindow ControlWindow;
    public ProductionItemList ProductionItemList;
    private GameObject _currentlySelected;

    private void Start()
    {
        ControlWindow.Hide();
    }

    private void Update ()
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

                    ProductionItemList.AddProductionItem("Hello world");
                }
            }

            if (_currentlySelected)
            {
                ControlWindow.Show();
            }
            else
            {
                ControlWindow.Hide();
            }
        }
	}
}
