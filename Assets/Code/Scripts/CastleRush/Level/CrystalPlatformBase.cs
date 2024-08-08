using UnityEngine;
using Generics;
using CastleRush.Units;
using System.Collections;

namespace CastleRush 
{
    [RequireComponent(typeof(HealthComponent))]
    public class CrystalPlatformBase : MonoBehaviour
    {
        public delegate void PlatformBaseAction();
        public static event PlatformBaseAction OnMatchLost;

        HealthComponent healthComponent
            => GetComponent<HealthComponent>();

        [SerializeField] public bool IsAlive 
            => healthComponent.IsAlive;

        private void OnEnable()
        {
            StartCoroutine(LivingCoroutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        IEnumerator LivingCoroutine()
        {
            while (true)
            {
                if(!IsAlive)
                    NotifyDead();

                yield return null;
            }
        }

        private void NotifyDead()
        {
            StopAllCoroutines();

            if(OnMatchLost != null)
                OnMatchLost();

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out NPCEnemy npcEnemy))
            {
                healthComponent.Hit(npcEnemy.DamageValue);
            }
        }
    }
}
