using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public class ShieldedEnemyBehaviour : EnemyBehaviour
    {
        public ShieldedEnemyBehaviour(ShieldedEnemy enemy) : base(enemy)
        {
        }
        
        protected override void Init(Enemy enemy)
        {
            ShieldedEnemy shieldedEnemy = enemy as ShieldedEnemy;

            States = new List<BaseEnemyState>()
            {
                new ArmouredAttackState(shieldedEnemy, this),
                new AttackState(enemy, this),
                new ShieldAttackState(shieldedEnemy, this),
                new FastAttackState(enemy, this),
                new DiedState(enemy, this)
            };
            
            CurrentState = States.FirstOrDefault(state => state is DiedState);
            CurrentState.StartState();
        }
    }
}