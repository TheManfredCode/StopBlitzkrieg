using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class EnemyBehaviour : IStateSwitcher
    {
        private BaseEnemyState _currentState;
        private List<BaseEnemyState> _states;

        public EnemyBehaviour(Enemy enemy)
        {
            _states = new List<BaseEnemyState>()
            {
                new AttackState(enemy, this),
                new ShieldAttackState(enemy, this),
                new FastAttackState(enemy, this),
                new DiedState(enemy, this)
            };
            
            _currentState = _states.FirstOrDefault(state => state is DiedState);
            _currentState.StartState();
        }

        public void ChangeState<T>() where T : BaseEnemyState
        {
            _currentState.FinishState();
            var newState = _states.FirstOrDefault(state => state is T);
            newState.StartState();
            _currentState = newState;
        }

        public void OnClick() => 
            _currentState.OnClick();
    }
}