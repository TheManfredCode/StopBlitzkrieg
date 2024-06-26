namespace DefaultNamespace
{
    public class AttackState : BaseEnemyState
    {
        public AttackState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
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
            if (EnemyEntity.HasShield)
            {
                StateSwitcher.ChangeState<ShieldAttackState>();
                return;
            }
            
            StateSwitcher.ChangeState<FastAttackState>();
        }
    }
}