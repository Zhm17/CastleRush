using CastleRush.Data;
using CastleRush.Data.Config;

using UnityEngine;
using System.Collections.Generic;

namespace CastleRush.Units {
    public class NPCEnemyWaveSpawner : MonoBehaviour
    {
        public SpawnerType Type => SpawnerType.NPC_ENEMY;

        [SerializeField] private Transform[] SpawnerParentsT;



        private Dictionary<int, NPCEnemyWaveDataSet> m_waveDataSet = CastleRushConfig.NPCEnemyWavesLib;
        public Dictionary<int, NPCEnemyWaveDataSet> WaveDataSet => m_waveDataSet;


        // NPC Enemy Spawners
        private NPCEnemySpawner m_npcEnemySpawner;
        private NPCEnemySpawner NPCEnemySpawner
        {
            get
            {
                if (null == m_npcEnemySpawner)
                {
                    m_npcEnemySpawner = new NPCEnemySpawner();
                    m_npceChestSpawner.SetSpawnerParent(SpawnerParentsT[0]);
                }
                return m_npcEnemySpawner;
            }
        }


        private NPCECrabSpawner m_npceCrabSpawner;
        private NPCECrabSpawner NPCECrabSpawner 
        { 
            get 
            {
                if (null == m_npceCrabSpawner)
                {
                    m_npceCrabSpawner = new NPCECrabSpawner();
                    m_npceCrabSpawner.SetSpawnerParent(SpawnerParentsT[1]);
                }
                return m_npceCrabSpawner;    
            } 
        }

        private NPCEWormSpawner m_npceWormSpawner;
        private NPCEWormSpawner NPCEWormSpawner
        {
            get
            {
                if (null == m_npceWormSpawner)
                {
                    m_npceWormSpawner = new NPCEWormSpawner();
                    m_npceWormSpawner.SetSpawnerParent(SpawnerParentsT[2]);
                }
                return m_npceWormSpawner;
            }
        }

        private NPCEChestSpawner m_npceChestSpawner;
        private NPCEChestSpawner NPCEnemyChestSpawner 
        {
            get
            {
                if (null == m_npceChestSpawner)
                {
                    m_npceChestSpawner = new NPCEChestSpawner();
                    m_npceChestSpawner.SetSpawnerParent(SpawnerParentsT[3]);
                }
                return m_npceChestSpawner;
            }
        }


        // Start is called before the first frame update
        private void Awake()
        {

        }

        public virtual NPCEnemy CreateNSetEnemy(NPCEnemyStats stats)
        {
            NPCEnemy newEnemy = null;

            switch (stats.type)
            {
                case NPCEnemyType.TEST:
                    newEnemy = NPCEnemySpawner.Create();
                    break;
                case NPCEnemyType.CRAB:
                    newEnemy = NPCECrabSpawner.Create();
                    break;
                case NPCEnemyType.WORM:
                    newEnemy = NPCEWormSpawner.Create();
                    break;
                case NPCEnemyType.CHEST:
                    newEnemy = NPCEnemyChestSpawner.Create();
                    break;
            }

            //TODO SetStats
            //newEnemy.Set();
            return newEnemy;
        }


    }
}
