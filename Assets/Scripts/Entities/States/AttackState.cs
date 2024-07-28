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
            if (!EnemyEntity.IsClickable) return;
            
            StateSwitcher.ChangeState<DiedState>();
        }
    }
}