using DefaultNamespace;
using UnityEngine;

public class PlayerInputController
{
    private Camera _mainCamera;
    private InputManager _inputManager;

    public PlayerInputController()
    {
        _mainCamera = Camera.main;
        _inputManager = new InputManager();
        _inputManager.OnStartTouch += OnTouch;
    }

    private void OnTouch(Vector2 screenPosition, float time)
    {
        var clickedCollider = GetRayIntersection(screenPosition).collider;
            
        if (!clickedCollider) return;
            
        if(clickedCollider.TryGetComponent(out IClickable clickableObject))
            clickableObject.OnClick();
    }

    private RaycastHit2D GetRayIntersection(Vector2 touchPosition)
    {
        var ray = _mainCamera.ScreenPointToRay(touchPosition);
        return Physics2D.GetRayIntersection(ray);
    }
}