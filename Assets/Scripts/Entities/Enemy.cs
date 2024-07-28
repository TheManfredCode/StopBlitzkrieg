using System;
using DefaultNamespace;
using DefaultNamespace.Movers;
using UnityEngine;

public class Enemy : MonoBehaviour, IClickable
{
    [SerializeField] protected EnemyMover _mover;
    [SerializeField] protected EnemyView _view;
    [SerializeField] private float _dieAnimationTime;

    protected EnemyBehaviour _enemyBehaviour;
    private bool _isClickable;

    public event Action Killed;

    public bool IsClickable => _isClickable;

    private void Awake() => 
        OnAwake();
    
    protected virtual void OnAwake() => 
        _enemyBehaviour = new EnemyBehaviour(this);
    
    public void EnableClickable() =>
        _isClickable = true;

    public void SwitchFastMoveMode(bool isHardModeOn) =>
        _mover.SwitchFastMoveMode(isHardModeOn);

    public void ChangeSprite(Sprite sprite) =>
        _view.SetSprite(sprite);

    public void StartDieAnimation()
    {
        _mover.StopMoving();
        _view.StartDissolve(() => Die(), _dieAnimationTime);
    }

    public void Die(bool isInitializing = false)
    {
        if(!isInitializing) 
            Killed?.Invoke();

        _isClickable = false;
        gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        _view.ResetDissolveEffect();
        _mover.Restart();
        _enemyBehaviour.ChangeState<AttackState>();
    }

    public void OnClick() =>
        _enemyBehaviour.OnClick();
    
    private void OnDisable() =>
        _isClickable = false;

    public void ResetClickable() =>
        _isClickable = false;
}