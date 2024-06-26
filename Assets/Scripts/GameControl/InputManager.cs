using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    
    private TouchControlls _touchControlls;

    public InputManager()
    {
        _touchControlls = new TouchControlls();
        _touchControlls.Enable();
        Start();
    }

    private void Start()
    {
        _touchControlls.Touch.TouchPress.started += callbackContext => StartTouch(callbackContext);
        _touchControlls.Touch.TouchPress.canceled += callbackContext => EndTouch(callbackContext);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(_touchControlls.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.startTime);
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(_touchControlls.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.time);
    }
}
