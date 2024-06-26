using System;
using DefaultNamespace;
using DefaultNamespace.Movers;
using UnityEngine;

public class Enemy : MonoBehaviour, IClickable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyView _view;

    private EnemyBehaviour _enemyBehaviour;
    private bool _isClickable;
    private bool _hasShield = true;

    public event Action Killed;

    public bool IsClickable => _isClickable;

    public bool HasShield => _hasShield;

    private void Awake()
    {
        _enemyBehaviour = new EnemyBehaviour(this);
    }

    public void EnableClickable()
    {
        _isClickable = true;
    }

    public void SwitchFastMoveMode(bool isHardModeOn)
    {
        _mover.SwitchFastMoveMode(isHardModeOn);
    }

    public void ChangeSprite(Sprite sprite)
    {
        _view.SetSprite(sprite);
    }

    public void ChangeShieldVisible(bool value)
    {
        if (value)
        {
            _view.ChangeShieldVisible(true);
            _hasShield = false;
            _isClickable = false;
            _view.ChangeShieldIndicatorVisible(false);
            return;
        }

        _isClickable = true;
        _view.ChangeShieldVisible(false);
    }

    public void Die(bool isInitializing = false)
    {
        if(!isInitializing) 
            Killed?.Invoke();

        _isClickable = false;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _enemyBehaviour.ChangeState<AttackState>();
    }

    public void Teleport()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x + 100, position.y);
    }

    public void OnClick()
    {
        _enemyBehaviour.OnClick();
    }

    private void OnDisable()
    {
        _isClickable = false;
    }
}