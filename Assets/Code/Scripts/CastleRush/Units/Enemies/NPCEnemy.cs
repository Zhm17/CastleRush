using UnityEngine;
using Generics;
using Utils;

namespace CastleRush.Units
{
    [RequireComponent(typeof(HealthComponent), typeof(FollowWaypoints), typeof(Animator))]
    public abstract class NPCEnemy : ItemPool, IDamageable
    {
        [SerializeField] public virtual NPCEnemyType Type => NPCEnemyType.TEST;

        // Damage to inflict
        protected int m_damageValue = 1;
        public int DamageValue => m_damageValue;
        public void SetDamageValue(int value) 
            => m_damageValue = value;

        
        // TODO Maybe add an State AWAKE, WALK, DEAD, FINISH

        // TODO Maybe add Status like FROZEN, POISONED, PARALYZED, ...


        // Components
        protected HealthComponent Health => GetComponent<HealthComponent>();
        protected Animator Animator => GetComponent<Animator>();
        protected FollowWaypoints PathWalker => GetComponent<FollowWaypoints>();



        protected override void OnEnable()
        {
            base.OnEnable();
            Active();
        }

        public virtual void Set(int id, NPCEnemyStats stats)
        {
            // Set id
            SetID(id);

            // Set stats
            SetLifeTime(stats.lifeTime);
            SetDamageValue(stats.damageValue);
            Health.SetMaxHealth(stats.maxHealth);
            PathWalker.SetStartWalkSpeed(stats.startWalkSpeed);
        }

        protected virtual void Active() 
        {
            PathWalker?.StartWalking();
        }

        protected virtual void Hit(int value) 
        {
            Health?.Hit(value);
        }

        protected virtual void Die() 
        {
            Animator?.SetBool("Dead", true);
        }

        protected virtual void Sleep() {
            gameObject.SetActive(false);
        }

        protected virtual void Finish()
        {
            // TODO Inflict damage to Player
            // Player.Hit(DamageValue);
        }

    }
}
