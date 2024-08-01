using Generics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Units
{
    [RequireComponent(typeof(RotateTowardsTarget))]
    public class NPCEnemyTargetDetector : MonoBehaviour
    {
        [Header("NPC Enemy Target")]
        [SerializeField] protected NPCEnemy m_Target = null;
        public NPCEnemy Target 
            => m_Target;
        protected void SetTarget(NPCEnemy enemyTarget)
            => m_Target = enemyTarget;

        [Header("Near Enemies Detected")]
        [SerializeField] protected List<NPCEnemy> m_nearEnemiesList;
        protected List<NPCEnemy> NearEnemiesList
        {
            get
            {
                if (m_nearEnemiesList == null)
                    m_nearEnemiesList = new List<NPCEnemy>();
                return m_nearEnemiesList;
            }
        }
        protected void AddNewTarget(NPCEnemy enemyTarget)
            => m_nearEnemiesList.Add(enemyTarget);

        protected void RemoveEnemy(NPCEnemy nearEnemy) 
            => m_nearEnemiesList.Remove(nearEnemy);


        protected virtual void ResetNearEnemiesList()
        {
            if (null != m_nearEnemiesList)
                m_nearEnemiesList.Clear();
        }

        protected void SetNextTarget()
        {
            if (NearEnemiesList.Count < 1)
            {
                SetTarget(null);
                return;
            }
            
            SetTarget(NearEnemiesList[0]);
        }

        private void OnEnable()
        {
            StopAllCoroutines();
            StartCoroutine(AimingCoroutine());
        }

        private void OnDisable() 
        {
            StopAllCoroutines();
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        IEnumerator AimingCoroutine()
        {
            while (true)
            {
                if (Target &&
                    TryGetComponent(out RotateTowardsTarget rttComponent))
                        rttComponent.SetTarget(Target.transform);
                yield return null;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NPCEnemy enemyTarget))
            {
                AddNewTarget(enemyTarget);

                if (!Target || 
                    !Target.gameObject.activeInHierarchy)
                    SetNextTarget();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out NPCEnemy enemyTarget)
                && NearEnemiesList.Contains(enemyTarget))
            {
                RemoveEnemy(enemyTarget);
                SetNextTarget();
            }
        }
    }
}
