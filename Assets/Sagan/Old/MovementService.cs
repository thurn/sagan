using UnityEngine;

public class MovementService : SaganService
{
    private ControlWindow _movementWindow;

    public void ShowMovementWindowForUnit(Unit unit)
    {
        if (_movementWindow == null)
        {
            _movementWindow = Root.InstantiatePrefabComponent<ControlWindow>(Root.ControlWindow, Root.MainCanvas.transform);
        }
        _movementWindow.gameObject.SetActive(true);
        ShowMovement();
    }

    private void ShowMovement()
    {
    }
}