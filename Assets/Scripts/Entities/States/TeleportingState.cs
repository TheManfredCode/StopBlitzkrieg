namespace DefaultNamespace
{
    public class TeleportingState : BaseEnemyState
    {
        public TeleportingState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
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
            EnemyEntity.Teleport();
            StateSwitcher.ChangeState<AttackState>();
        }
    }
}