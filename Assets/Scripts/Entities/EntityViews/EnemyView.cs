using System;
using Effects;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private DissolveEffectView _dissolveEffect;

    public void SetSprite(Sprite sprite) =>
        _spriteRenderer.sprite = sprite;

    public void ResetDissolveEffect() => 
        _dissolveEffect.ResetEffect();
    
    public void StartDissolve(Action callback, float seconds) =>
        _dissolveEffect.StartDissolve(callback, seconds);
}