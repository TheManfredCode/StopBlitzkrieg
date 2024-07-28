using UnityEngine;

namespace DefaultNamespace.Movers
{
    public class EnemyMover : EntityMover
    {
        [SerializeField] private float _hardModeSpeed;

        public void Restart()
        {
            CurrentSpeed = Speed;
        }
        
        public void StopMoving()
        {
            CurrentSpeed = 0;
        }
        
        public void SwitchFastMoveMode(bool isHardModeOn)
        {
            CurrentSpeed = isHardModeOn ? _hardModeSpeed : Speed;
        }
    }
}