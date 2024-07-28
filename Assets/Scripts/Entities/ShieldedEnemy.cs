using DefaultNamespace.EntityViews;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShieldedEnemy : Enemy
    {
        [SerializeField] private int _shieldedStateDuration = 1000;
        
        private bool _hasShield = true;
        
        private ShieldedEnemyView _shieldedView => _view as ShieldedEnemyView;
        
        public bool HasShield => _hasShield;

        public int ShieldedStateDuration => _shieldedStateDuration;

        protected override void OnAwake() =>
            _enemyBehaviour = new ShieldedEnemyBehaviour(this);

        public override void Activate()
        {
            _view.ResetDissolveEffect();
            _shieldedView.ReserShields();
            _mover.Restart();
            _enemyBehaviour.ChangeState<ArmouredAttackState>();
            _hasShield = true;
        }

        public void ChangeShieldVisible(bool value)
        {
            if (value)
            {
                _shieldedView.ChangeShieldVisible(true);
                _hasShield = false;
                _shieldedView.ChangeShieldIndicatorVisible(false);
                return;
            }

            _shieldedView.ChangeShieldVisible(false);
        }
    }
}