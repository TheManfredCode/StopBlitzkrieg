namespace DefaultNamespace
{
    public class FastAttackState : BaseEnemyState
    {
        public FastAttackState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }

        public override void StartState()
        {
            EnemyEntity.SwitchFastMoveMode(true);
        }

        public override void FinishState()
        {
            EnemyEntity.SwitchFastMoveMode(false);
        }

        public override void OnClick()
        {
            StateSwitcher.ChangeState<DiedState>();
        }
    }
}