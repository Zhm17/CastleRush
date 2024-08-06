using System.Collections;
using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    [RequireComponent(typeof(Rigidbody))]
    public class WTAmmo : ItemPool
    {
        [SerializeField] public virtual WTAmmoType AmmoType
            => WTAmmoType.DEFAULT_AMMO;

        // Bullet Traject and Interaction
        [Header("Target")]
        [SerializeField] protected Transform m_target = null;
        public Transform Target 
            => m_target;
        public void SetTarget(Transform target)  
            => m_target = target;


        [Header("Damage Values")]
        [SerializeField] protected int m_damageValue = 1;
        public int DamageValue 
            => m_damageValue;
        public void SetDamage(int damage) 
            => m_damageValue = damage;

        [Header("Projectile Speed")]
        [SerializeField] protected float m_speed = 5f;
        public float Speed 
            => m_speed;
        public void SetSpeed(float speed) 
            => m_speed = speed;

        // TODO Set Bullet impact prefabq
        [Header("VFX")]
        [SerializeField] protected ParticleSystem m_impactVFX;
        public ParticleSystem ImpactVFX 
            => m_impactVFX;
        public void SetImpactVFX(ParticleSystem particleSystemVFX)
            => m_impactVFX = particleSystemVFX;


        protected override void OnEnable()
        {
            StartCoroutine(TrajectoryCoroutine());
        }

        protected override void OnDisable()
        {
            StopAllCoroutines();
        }

        protected override void OnDestroy()
        {
            StopAllCoroutines();
        }

        IEnumerator TrajectoryCoroutine()
        {
            while(null != Target)
            {
                Vector3 dir = Target.position - transform.position;
                float distanceThisFrame = Speed * Time.deltaTime;

                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
                transform.LookAt(Target);

                yield return null;
            }
        }
        
        protected virtual void HitTarget(NPCEnemy enemy)
        {
            StopAllCoroutines();

            enemy.Hit(DamageValue);

            ReturnToPool();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //TODO Spawn / Play / ask for impact VFX

            if (collision.transform.TryGetComponent(out NPCEnemy enemy))
            {
                HitTarget(enemy);
            }
        }

    }
}
