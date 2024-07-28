namespace DefaultNamespace
{
    public class DiedState : BaseEnemyState
    {
        public DiedState(Enemy enemy, IStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
        {
        }
        
        public override void StartState()
        {
            EnemyEntity.StartDieAnimation();
        }

        public override void FinishState() { }

        public override void OnClick() { }
    }
}