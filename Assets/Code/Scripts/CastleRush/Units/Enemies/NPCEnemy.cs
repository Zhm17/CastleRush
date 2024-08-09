using UnityEngine;
using Generics;
using Utils;
using CastleRush.Data;
using System.Collections;

namespace CastleRush.Units
{
    [RequireComponent(typeof(HealthComponent), typeof(FollowWaypoints), typeof(Animator))]
    public class NPCEnemy : ItemPool, IDamageable
    {
        public delegate void EnemyBeat(int value = 0);
        public static event EnemyBeat OnEnemyBeaten;

        [SerializeField] public virtual NPCEnemyType Type => NPCEnemyType.TEST;

        // Damage to inflict
        protected int m_damageValue = 1;
        public int DamageValue 
            => m_damageValue;
        public void SetDamageValue(int value) 
            => m_damageValue = value;


        // Points to Score
        // TODO Add to the enemy stats
        [SerializeField] protected int m_pointsToScore = 1;
        public int PointsToScore 
            => m_pointsToScore;
        public void SetPointsToScore(int pointsToScore)
            => m_pointsToScore = pointsToScore;

     
        // TODO Add an State AWAKE, WALK, DEAD, FINISH

        // TODO Add Status like FROZEN, POISONED, PARALYZED, ...

        // Components
        protected Animator Animator 
            => GetComponent<Animator>();
        protected FollowWaypoints PathWalker 
            => GetComponent<FollowWaypoints>();
        protected HealthComponent Health 
            => GetComponent<HealthComponent>();

        [SerializeField] public bool IsAlive
           => Health.IsAlive;

        protected override void OnEnable()
        {
            base.OnEnable();
            Active();
        }

        public virtual void Set(NPCEWaveUnit unit)
        {
            // Set id
            SetID(unit.ID);

            // Set stats
            SetLifeTime(unit.Stats.lifeTime);
            SetDamageValue(unit.Stats.damageValue);
            Health.SetMaxHealth(unit.Stats.maxHealth);
            PathWalker.SetStartWalkSpeed(unit.Stats.startWalkSpeed);
        }

        protected virtual void Active() 
        {
            PathWalker?.StartWalking();
            StartCoroutine(LivingCoroutine());
        }

        public virtual void Hit(int value) 
        {
            Health?.Hit(value);
        }

        protected IEnumerator LivingCoroutine()
        {
            while (true)
            {
                if (!IsAlive)
                    NotifyDead();

                yield return null;
            }
        }

        protected virtual void NotifyDead() 
        {
            StopAllCoroutines();

            if (OnEnemyBeaten != null)
                OnEnemyBeaten(PointsToScore);

            //Disable Collision and Physic components
            GetComponent<Collider>().enabled = false;
            
            if(TryGetComponent(out Rigidbody rigidbody))
                rigidbody.Sleep();

            // TODO NPC Enemy Death - improve animation
            // TODO NPC Enemy Death - improve with explosion VFX
            Animator?.SetBool("Dead", true);

            gameObject.SetActive(false);
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent(out WTAmmo ammoBullet))
                Hit(ammoBullet.DamageValue);
        }

    }
}
