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
                //TODO return original behaviour
                // StateSwitcher.ChangeState<ShieldAttackState>();
                StateSwitcher.ChangeState<DiedState>();
                return;
            }
            
            StateSwitcher.ChangeState<FastAttackState>();
        }
    }
}