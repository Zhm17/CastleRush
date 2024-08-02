using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTurret : ItemPool
    {
        [SerializeField] public virtual WTurretType Type 
            => WTurretType.DEFAULT;

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


        [Header("Fire Properties")]
        [SerializeField] protected Transform m_firePoint;
        public Transform FirePoint 
            => m_firePoint;

        [Header("Cooldown")]
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



        [Header("Prefab")]
        [SerializeField] protected WTAmmo m_ammoPrefab;
        public WTAmmo AmmoPrefab => m_ammoPrefab;


        protected virtual void Shoot() { }

    }
}
