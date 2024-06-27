namespace DefaultNamespace
{
    public class ShieldAttackState : BaseEnemyState
    {
        private int _stateDuration = 3000;
        private uint _timeout;
        
        public ShieldAttackState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }
        
        public override void StartState()
        {
            EnemyEntity.ChangeShieldVisible(true);
            _timeout = Ticker.SetTimeout(StartNextState, _stateDuration);
        }

        public override void FinishState()
        {
            EnemyEntity.ChangeShieldVisible(false);
            Ticker.ClearTimeout(_timeout);
        }

        public override void OnClick()
        {
            
        }

        private void StartNextState()
        {
            StateSwitcher.ChangeState<AttackState>();
        }
    }
}