using CastleRush.Units;
using UnityEngine;
using Utils;

namespace CastleRush
{
    [RequireComponent(typeof(NPCEnemyWaveSpawner))]
    public class StageManager : Singleton<StageManager>
    {
        [SerializeField] private int m_stageNumber = 1;
        public int StageNumber => m_stageNumber;

        NPCEnemyWaveSpawner EnemyWaveSpawner
        {
            get
            {
                if(TryGetComponent(out NPCEnemyWaveSpawner spawner))
                {
                    return spawner;
                }
                return null;
            }
        }

        protected override void Init()
        {

        }
    }
}
