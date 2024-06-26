namespace DefaultNamespace
{
    public class ShieldAttackState : BaseEnemyState
    {
        private int stateDuration = 2000;
        
        public ShieldAttackState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }
        
        public override void StartState()
        {
            EnemyEntity.ChangeShieldVisible(true);
            Ticker.SetTimeout(StartNextState, 2000);
        }

        public override void FinishState()
        {
            EnemyEntity.ChangeShieldVisible(false);
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