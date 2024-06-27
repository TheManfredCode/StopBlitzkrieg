using System;
using System.Collections.Generic;

public class EnemySpawner : ObjectPool<Enemy>
{
    public event Action EnemyKilled; 

    public List<Enemy> EnemiesPool => Pool;

    private void OnEnemyKilled()
    {
        EnemyKilled?.Invoke();
    }

    public void SwitchHardMode(bool isHardModeOn)
    {
        foreach (var enemy in Pool)
            enemy.SwitchFastMoveMode(isHardModeOn);
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
}