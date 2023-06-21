using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private InputManager _inputManager;

    private void OnEnable()
    {
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

    private void OnDisable()
    {
        _inputManager.OnStartTouch += OnTouch;
    }
}