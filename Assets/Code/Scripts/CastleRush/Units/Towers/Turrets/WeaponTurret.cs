using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WeaponTurret : ItemPool
    {
        [SerializeField] public virtual TurretType Type => TurretType.DEFAULT;

        [Header("Target Detector")]
        [SerializeField] protected NPCEnemyTargetDetector m_targetDetector;
        public NPCEnemyTargetDetector TargetDetector
        {
            get
            {
                if (null == m_targetDetector)
                    m_targetDetector = gameObject.AddComponent<NPCEnemyTargetDetector>();
                return m_targetDetector;
            }
        }


        [Header("Shooting Timer")]
        [SerializeField] protected float m_shootingCooldownTime = 0.5f;
        public float ShootCooldownTime 
            => m_shootingCooldownTime;
        public void SetShootingCooldownTime(float timeInSeconds) 
            => m_shootingCooldownTime = timeInSeconds;

        [SerializeField] protected float m_shootingCooldownTimeRemaining = 0f;
        public float ShootingCooldownTimeRemaining 
            => m_shootingCooldownTimeRemaining;
        public void ReduceShootingCooldownTimeRemaining(float timeInSeconds)
            => m_shootingCooldownTimeRemaining -= timeInSeconds;

        protected virtual void DetectEnemy() { }
        protected virtual void Aim() { }
        protected virtual void Shoot() { }

    }
}
