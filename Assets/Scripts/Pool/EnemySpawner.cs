using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

public class EnemySpawner : ObjectPool<Enemy>
{
    private EnemiesSpritesController _spritesController;
    
    public event Action EnemyKilled; 

    public List<Enemy> EnemiesPool => Pool;

    [Inject]
    private void Construct(EnemiesSpritesController spritesController)
    {
        _spritesController = spritesController;
        
        AfterConstructed();
    }

    private void AfterConstructed()
    {
        _spritesController.SpriteUpdated += OnSpriteUpdated;
    }

    public override void Init()
    {
        base.Init();
        var currentSprite = _spritesController.GetCurrentSprite();
        
        if(currentSprite != null)
            OnSpriteUpdated(currentSprite);
    }

    private void OnEnemyKilled()
    {
        EnemyKilled?.Invoke();
    }

    public void SwitchHardMode(bool isHardModeOn)
    {
        foreach (var enemy in Pool)
            enemy.SwitchFastMoveMode(isHardModeOn);
    }

    private void OnSpriteUpdated(Sprite sprite)
    {
        foreach (var enemy in Pool)
            enemy.ChangeSprite(sprite);
    }

    protected override void ActivateObject(Enemy poolObject)
    {
        base.ActivateObject(poolObject);
        poolObject.Activate();
    }

    protected override void RestartPoolObject(Enemy poolObject)
    {
        base.RestartPoolObject(poolObject);
        poolObject.SwitchFastMoveMode(false);
    }

    protected override void AfterObjectInstantiated(Enemy poolObject)
    {
        base.AfterObjectInstantiated(poolObject);
        poolObject.Killed += OnEnemyKilled;
    }

    protected override void Clear()
    {
        base.Clear();
        _spritesController.SpriteUpdated -= OnSpriteUpdated;
    }
}