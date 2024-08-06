using System.Collections;
using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTurret : ItemPool
    {
        public virtual WTurretType Type 
            => WTurretType.DEFAULT;

        public virtual WTAmmoType AmmoType
            => WTAmmoType.DEFAULT_AMMO;


        protected NPCEnemyTargetDetector m_targetDetector;
        public NPCEnemyTargetDetector TargetDetector
        {
            get
            {
                if (null == m_targetDetector)
                    m_targetDetector = gameObject.AddComponent<NPCEnemyTargetDetector>();
                return m_targetDetector;
            }
        }
        public NPCEnemy Target
            => TargetDetector!.Target;



        [Header("Fire Properties")]
        [SerializeField] protected Transform m_firePoint;
        public Transform FirePoint 
            => m_firePoint;


        // Cooldown Time
        [Header("Cooldown")]
        [SerializeField] protected float m_cooldownTime = 0.5f;
        public float CooldownTime 
            => m_cooldownTime;
        public void SetShootingCooldownTime(float timeInSeconds) 
            => m_cooldownTime = timeInSeconds;
        


        [SerializeField] protected float m_timeRemaining = 0f;
        public float TimeRemaining 
            => m_timeRemaining;
        public void ResetTimeRemaining()
            => m_cooldownTime = CooldownTime;
        public void ReduceTimeRemaining(float timeInSeconds)
            => m_timeRemaining -= timeInSeconds;



        protected override void OnEnable()
        {
            StartCoroutine(ShootCoroutine());
        }

        protected override void OnDisable()
        {
            StopAllCoroutines();
        }

        protected override void OnDestroy()
        {
            StopAllCoroutines();
        }

        protected virtual void Shoot()
        {
            WTAmmo bullet =
                WTABulletFactory.
                    Instance.
                        CreateNSet(
                            AmmoType,
                            FirePoint.position,
                            Target.transform
                        );

            ResetTimeRemaining();
        }
        

        protected IEnumerator ShootCoroutine()
        {
            while (true)
            {
                ReduceTimeRemaining(Time.deltaTime);

                if ( TimeRemaining <= 0f &&
                     null != Target )
                            Shoot();

                yield return true;
            }
        }
    }
}
