using CastleRush.Data;
using CastleRush.Data.Config;

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace CastleRush.Units {
    public class NPCEnemyWaveSpawner : MonoBehaviour
    {
        public SpawnerType Type => SpawnerType.NPC_ENEMY;

        

        // Wave Data Set
        private StageManager Stage => StageManager.Instance;
        public Dictionary<int, NPCEWaveDataSet> WavesLib => CastleRushConfig.NPCEnemyWavesLib;

        private NPCEWaveDataSet m_npceCurrentWaveDataSet
        {
            get
            {
                if (WavesLib.ContainsKey(Stage.StageNumber))
                    return WavesLib[Stage.StageNumber];
                return null;
            }
        }
        public NPCEWaveDataSet CurrentWaveDataSet => m_npceCurrentWaveDataSet;


        // Time
        [SerializeField] private float m_startCountDownTime = 6f;
        public float StartCountdownT
        {
            get
            {
                if (null != CurrentWaveDataSet)
                    return CurrentWaveDataSet.StartCountDownTime;
                return m_startCountDownTime;
            }
        }

        [SerializeField] private float m_cooldownTimeBetweenUnits = 2f;
        public float CooldownTimeBetweenUnits
        {
            get 
            {
                if (null != CurrentWaveDataSet)
                    return CurrentWaveDataSet.CooldownTimeBetweenUnits;
                return m_cooldownTimeBetweenUnits;
            }
        }

        // NPC Enemy Wave Units
        [SerializeField] public static List<NPCEWaveUnit> m_npceWaveUnits;
        public List<NPCEWaveUnit> WaveUnits
        {
            get
            {
                if (null == m_npceWaveUnits)
                    m_npceWaveUnits = CurrentWaveDataSet.NPCEWaveUnits;
                return m_npceWaveUnits;
            }
        }

        [Header("Transform parents")]
        [SerializeField] private Transform[] SpawnerParentsT;

        // NPC Enemy Spawners
        private NPCEnemySpawner m_npcEnemySpawner;
        private NPCEnemySpawner DefaultSpawner
        {
            get
            {
                if (null == m_npcEnemySpawner)
                {
                    m_npcEnemySpawner = gameObject.AddComponent<NPCEnemySpawner>();
                    m_npceChestSpawner.SetSpawnerParent(SpawnerParentsT[0]);
                }
                return m_npcEnemySpawner;
            }
        }


        private NPCECrabSpawner m_npceCrabSpawner;
        private NPCECrabSpawner CrabSpawner 
        { 
            get 
            {
                if (null == m_npceCrabSpawner)
                {
                    m_npceCrabSpawner = gameObject.AddComponent<NPCECrabSpawner>();
                    m_npceCrabSpawner.SetSpawnerParent(SpawnerParentsT[1]);
                }
                return m_npceCrabSpawner;    
            } 
        }


        private NPCEWormSpawner m_npceWormSpawner;
        private NPCEWormSpawner WormSpawner
        {
            get
            {
                if (null == m_npceWormSpawner)
                {
                    m_npceWormSpawner = gameObject.AddComponent<NPCEWormSpawner>();
                    m_npceWormSpawner.SetSpawnerParent(SpawnerParentsT[2]);
                }
                return m_npceWormSpawner;
            }
        }


        private NPCEChestSpawner m_npceChestSpawner;
        private NPCEChestSpawner ChestSpawner 
        {
            get
            {
                if (null == m_npceChestSpawner)
                {
                    m_npceChestSpawner = gameObject.AddComponent<NPCEChestSpawner>();
                    m_npceChestSpawner.SetSpawnerParent(SpawnerParentsT[3]);
                }
                return m_npceChestSpawner;
            }
        }



        public void StartSpawning()
        {
            StartCoroutine(WaveSpawnCoroutine());
        }

        IEnumerator WaveSpawnCoroutine()
        {
            yield return new WaitForSeconds(StartCountdownT);

            
            foreach(NPCEWaveUnit unit in WaveUnits) 
            {
                CreateNSetEnemy(unit);

                yield return new WaitForSeconds(CooldownTimeBetweenUnits); 
            }
        }

        public virtual NPCEnemy CreateNSetEnemy(NPCEWaveUnit unit)
        {
            NPCEnemy newEnemy = null;

            switch (unit.Stats.type)
            {
                case NPCEnemyType.TEST:
                    newEnemy = DefaultSpawner.Create();
                    break;
                case NPCEnemyType.CRAB:
                    newEnemy = CrabSpawner.Create();
                    break;
                case NPCEnemyType.WORM:
                    newEnemy = WormSpawner.Create();
                    break;
                case NPCEnemyType.CHEST:
                    newEnemy = ChestSpawner.Create();
                    break;
            }

            //SetStats
            newEnemy.Set(unit);
            
            return newEnemy;
        }

    }
}
