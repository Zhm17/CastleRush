using CastleRush.Units;
using Generics;
using UnityEngine;
using Utils;

namespace CastleRush
{
    [RequireComponent(typeof(NPCEnemyWaveSpawner), 
                        typeof(ScoreComponent))]
    public class StageManager : Singleton<StageManager>
    {
        [SerializeField] private int m_stageNumber;
        public int StageNumber 
            => m_stageNumber;

        public NPCEnemyWaveSpawner EnemyWaveSpawner
            => GetComponent<NPCEnemyWaveSpawner>();
        private ScoreComponent Scorer 
            => GetComponent<ScoreComponent>();

        protected override void Init() 
        {
            NPCEnemy.OnEnemyBeaten += Scorer.Scored;
        }

        private void OnDisable()
        {
            NPCEnemy.OnEnemyBeaten -= Scorer.Scored;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            NPCEnemy.OnEnemyBeaten -= Scorer.Scored;
        }

        public void StartMatch()
        {
            EnemyWaveSpawner.StartSpawning();

            Scorer.SetGoalScoreValue(EnemyWaveSpawner.WaveUnits.Count);
        }
    }
}
