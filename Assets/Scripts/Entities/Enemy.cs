using System;
using DefaultNamespace;
using DefaultNamespace.Movers;
using UnityEngine;

public class Enemy : MonoBehaviour, IClickable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyView _view;
    
    private bool _isClickable;

    public event Action Killed;

    public bool IsClickable => _isClickable;
    
    public void EnableClickable()
    {
        _isClickable = true;
    }

    public void SwitchHardMode(bool isHardModeOn)
    {
        _mover.SwitchHardModeSpeed(isHardModeOn);
    }

    public void ChangeSprite(Sprite sprite)
    {
        _view.SetSprite(sprite);
    }

    public void Die()
    {
        _isClickable = false;
        Killed?.Invoke();
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        if(_isClickable)
            Die();
    }

    private void OnDisable()
    {
        _isClickable = false;
    }
}