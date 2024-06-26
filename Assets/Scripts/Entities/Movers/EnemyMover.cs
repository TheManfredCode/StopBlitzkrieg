using UnityEngine;

namespace DefaultNamespace.Movers
{
    public class EnemyMover : EntityMover
    {
        [SerializeField] private float _hardModeSpeed;
        
        public void SwitchFastMoveMode(bool isHardModeOn)
        {
            CurrentSpeed = isHardModeOn ? _hardModeSpeed : Speed;
        }
    }
}