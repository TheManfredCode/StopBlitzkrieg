namespace DefaultNamespace
{
    public class ArmouredAttackState : BaseEnemyState
    {
        private ShieldedEnemy _shieldedEnemy => EnemyEntity as ShieldedEnemy;

        public ArmouredAttackState(ShieldedEnemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }

        public override void StartState()
        {
        }

        public override void FinishState()
        {
        }
        
        public override void OnClick()
        {
            if (!EnemyEntity.IsClickable) return;

            if (_shieldedEnemy.HasShield)
            {
                StateSwitcher.ChangeState<ShieldAttackState>();
                return;
            }
            
            StateSwitcher.ChangeState<FastAttackState>();
        }
    }
}