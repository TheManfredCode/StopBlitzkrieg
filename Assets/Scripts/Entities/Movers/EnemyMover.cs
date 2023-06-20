using UnityEngine;

namespace DefaultNamespace.Movers
{
    public class EnemyMover : EntityMover
    {
        [SerializeField] private float _hardModeSpeed;
        
        public void SwitchHardModeSpeed(bool isHardModeOn)
        {
            CurrentSpeed = isHardModeOn ? _hardModeSpeed : Speed;
        }
    }
}