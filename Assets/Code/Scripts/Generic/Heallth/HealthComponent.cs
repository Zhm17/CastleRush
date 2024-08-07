using UnityEngine;

namespace Generics
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
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
            // TODO
            // Dead Notification

            gameObject.SetActive(false);
        }

    }
}