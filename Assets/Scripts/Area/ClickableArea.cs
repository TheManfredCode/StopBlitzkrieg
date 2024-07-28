using System;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class ClickableArea : MonoBehaviour
{
    private GameplayController _gameplayController;

    [Inject]
    private void Construct(GameplayController gameplayController) =>
        _gameplayController = gameplayController;
    
    private void OnEnable() =>
        SetWidth(cameraWidth);

    private void OnTriggerEnter2D(Collider2D collision) =>
        OnClickableAreaEnter(collision);

    private void OnTriggerExit2D(Collider2D collision) =>
        OnClickableAreaExit(collision);

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
            if (enemy.IsClickable)
                _gameplayController.OnClickableAreaExit();
    }

    private float cameraWidth => Camera.main.orthographicSize * 2 * Camera.main.aspect;
}