using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _shieldIndicator;
    [SerializeField] private GameObject _shield;

    public void SetSprite(Sprite sprite) =>
        _spriteRenderer.sprite = sprite;

    public void ChangeShieldVisible(bool value) =>
        _shield.SetActive(value);

    public void ChangeShieldIndicatorVisible(bool value) =>
        _shieldIndicator.SetActive(value);
}