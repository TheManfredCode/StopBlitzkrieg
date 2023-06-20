using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private InputAction leftClick;
    [SerializeField] private Camera mainCamera;
        
    private void Start()
    {
        leftClick.Enable();
        leftClick.started += OnLeftClick;
    }
        
    private void OnLeftClick(InputAction.CallbackContext context)
    {
        var clickedCollider = GetRayIntersection().collider;
            
        if (!clickedCollider) return;
            
        if(clickedCollider.TryGetComponent(out IClickable clickableObject))
            clickableObject.OnClick();
    }

    private RaycastHit2D GetRayIntersection()
    {
        var ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        return Physics2D.GetRayIntersection(ray);
    }

    private void OnDisable()
    {
        leftClick.performed -= OnLeftClick;
        leftClick.Disable();
    }
}