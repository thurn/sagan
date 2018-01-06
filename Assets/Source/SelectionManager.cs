using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour {

    public UIWindow ControlWindow;
    private GameObject _currentlySelected;

	void Update ()
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
