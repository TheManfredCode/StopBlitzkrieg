namespace DefaultNamespace
{
    public abstract class BaseEnemyState
    {
        protected Enemy EnemyEntity;
        protected IStateSwitcher StateSwitcher;
        
        public BaseEnemyState(Enemy enemy, IStateSwitcher stateSwitcher)
        {
            EnemyEntity = enemy;
            StateSwitcher = stateSwitcher;
        }
        
        public abstract void StartState();

        public abstract void FinishState();

        public abstract void OnClick();
    }
}