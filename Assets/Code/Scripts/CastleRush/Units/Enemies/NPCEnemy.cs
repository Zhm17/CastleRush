using UnityEngine;
using Generics;
using Utils;
using CastleRush.Data;

namespace CastleRush.Units
{
    [RequireComponent(typeof(HealthComponent), typeof(FollowWaypoints), typeof(Animator))]
    public class NPCEnemy : ItemPool, IDamageable
    {
        [SerializeField] public virtual NPCEnemyType Type => NPCEnemyType.TEST;

        // Damage to inflict
        protected int m_damageValue = 1;
        public int DamageValue 
            => m_damageValue;
        public void SetDamageValue(int value) 
            => m_damageValue = value;

        
        // TODO Add an State AWAKE, WALK, DEAD, FINISH

        // TODO Add Status like FROZEN, POISONED, PARALYZED, ...


        // Components
        protected HealthComponent Health => GetComponent<HealthComponent>();
        protected Animator Animator => GetComponent<Animator>();
        protected FollowWaypoints PathWalker => GetComponent<FollowWaypoints>();



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

        protected virtual void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent(out WTAmmo ammoBullet))
            {
                // TODO for Ammo Damage Value
                Hit(1);
            }
        }

    }
}
