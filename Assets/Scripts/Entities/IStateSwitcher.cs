using DefaultNamespace;

public interface IStateSwitcher
{
    public void ChangeState<T>() where T : BaseEnemyState;
}