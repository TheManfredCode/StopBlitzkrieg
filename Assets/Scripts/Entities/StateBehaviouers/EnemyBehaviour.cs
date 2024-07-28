using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace DefaultNamespace
{
    public class EnemyBehaviour : IStateSwitcher
    {
        protected BaseEnemyState CurrentState;
        protected List<BaseEnemyState> States;

        public EnemyBehaviour(Enemy enemy) =>
            Init(enemy);

        protected virtual void Init(Enemy enemy)
        {
            States = new List<BaseEnemyState>()
            {
                new AttackState(enemy, this),
                new DiedState(enemy, this)
            };
            
            CurrentState = States.FirstOrDefault(state => state is DiedState);
            CurrentState.StartState();
        }

        public void ChangeState<T>() where T : BaseEnemyState
        {
            CurrentState.FinishState();
            var newState = States.FirstOrDefault(state => state is T);
            newState.StartState();
            CurrentState = newState;
        }

        public void OnClick() => 
            CurrentState.OnClick();
    }
}