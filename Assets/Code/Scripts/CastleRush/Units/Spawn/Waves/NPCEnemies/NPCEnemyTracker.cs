using Generics;
using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Units
{
    public class NPCEnemyTracker : MonoBehaviour
    {
        public delegate void EnemiesActiveInStageAction();
        public static event EnemiesActiveInStageAction OnAllEnemiesDisabled;

        [SerializeField] private Dictionary<int, bool> m_enemiesChecklist;
        public Dictionary<int, bool> EnemiesChecklist
        {
            get 
            {
                if (null == m_enemiesChecklist)
                    m_enemiesChecklist = new Dictionary<int, bool>();
                return m_enemiesChecklist;
            }
        }

        private void OnEnable()
        {
            FollowWaypoints.OnEndPath += Register;
            HealthComponent.OnDeath += Register;
        }

        private void OnDisable()
        {
            FollowWaypoints.OnEndPath -= Register;
            HealthComponent.OnDeath -= Register;
        }

        private void OnDestroy()
        {
            FollowWaypoints.OnEndPath -= Register;
            HealthComponent.OnDeath -= Register;
        }

        private void Register(GameObject npcGameObject)
        {
            if(npcGameObject.TryGetComponent(out NPCEnemy npcEnemy))
            {
                EnemiesChecklist.Add(npcEnemy.ID, false);

                if(EnemiesChecklist.Count  ==
                    StageManager.Instance.EnemyWaveSpawner.WaveUnits.Count)
                {
                    if(OnAllEnemiesDisabled!= null)
                        OnAllEnemiesDisabled();
                }
            }
        }

        public bool IsThereEnemiesalive()
        {
            foreach(bool active in EnemiesChecklist.Values)
            {
                if (active) return true;
            }

            return false;
        }
    }
}
