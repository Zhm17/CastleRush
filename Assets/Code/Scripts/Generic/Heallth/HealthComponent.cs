using UnityEngine;

namespace Generics
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        [SerializeField] protected bool m_isAlive = true;
        public bool IsAlive 
            => m_isAlive;
        public bool SetIsAlive(bool value)
            => m_isAlive = value;


        [SerializeField] protected int m_currentHealth = 3;
        public virtual int CurrentHealth 
            => m_currentHealth;
        public void SetCurrentHealth(int value) 
            => m_currentHealth = value;


        [SerializeField] protected int m_maxHealth = 3;
        public virtual int MaxHealth 
            => m_maxHealth;
        public void SetMaxHealth(int value) 
            => m_maxHealth = value;


        protected virtual void OnEnable()
        {
            ResetHealth();
        }

        /// <summary>
        /// Reset Health to max health
        /// </summary>
        public virtual void ResetHealth()
        {
            SetIsAlive(true);
            SetCurrentHealth(MaxHealth);
        }

        public virtual void Hit(int damageValue)
        {
            if (CurrentHealth > 0)
                SetCurrentHealth(CurrentHealth - damageValue);

            if (CurrentHealth <= 0)
                Die();
        }

        public virtual void Die() 
        {
            // TODO Dead Notification - Improvement
            // TODO Dead Notification - Remove it from NPCEnemy
            // TODO Dead Notification - Remove it from CrystalPlatformBase

            SetIsAlive(false);

            //gameObject.SetActive(false);
        }

    }
}