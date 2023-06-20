using System;
using UnityEngine;

public class ClickableArea : MonoBehaviour
{
    public event Action ClickableAreaExit;
    
    private void OnEnable()
    {
        SetWidth(cameraWidth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnClickableAreaEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnClickableAreaExit(collision);
    }

    private void SetWidth(float width)
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(width, localScale.y, localScale.z);
    }
    
    private void OnClickableAreaEnter(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.EnableClickable();
    }
    
    private void OnClickableAreaExit(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if(enemy.IsClickable)
            {
                ClickableAreaExit?.Invoke();
            }
        }
    }

    private float cameraWidth => Camera.main.orthographicSize * 2 * Camera.main.aspect;
}