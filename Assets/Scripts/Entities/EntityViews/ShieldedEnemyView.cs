using UnityEngine;

namespace DefaultNamespace.EntityViews
{
    public class ShieldedEnemyView : EnemyView
    {
        [SerializeField] private GameObject _shieldIndicator;
        [SerializeField] private GameObject _shield;
        
        public void ChangeShieldVisible(bool value) =>
            _shield.SetActive(value);

        public void ChangeShieldIndicatorVisible(bool value) =>
            _shieldIndicator.SetActive(value);

        public void ReserShields()
        {
            _shield.SetActive(false);
            _shieldIndicator.SetActive(true);
        }
    }
}