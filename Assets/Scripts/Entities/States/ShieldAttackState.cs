using System;

namespace DefaultNamespace
{
    public class ShieldAttackState : BaseEnemyState, IDisposable
    {
        private uint _timeout;
        
        private ShieldedEnemy _shieldedEnemy => EnemyEntity as ShieldedEnemy;
        
        public ShieldAttackState(ShieldedEnemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }
        
        public override void StartState()
        {
            _shieldedEnemy.ChangeShieldVisible(true);
            _timeout = Ticker.SetTimeout(StartNextState, _shieldedEnemy.ShieldedStateDuration);
        }

        public override void FinishState()
        {
            if(!_shieldedEnemy) return;
            
            _shieldedEnemy.ChangeShieldVisible(false);
            Ticker.ClearTimeout(_timeout);
        }

        public override void OnClick()
        {
        }

        private void StartNextState() =>
            StateSwitcher.ChangeState<AttackState>();

        public void Dispose() =>
            Ticker.ClearTimeout(_timeout);
    }
}