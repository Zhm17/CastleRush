using CastleRush.Data.Config;
using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class NPCEnemySpawner : ObjectPoolController, IFactory<NPCEnemy>
    {
        public virtual SpawnerType Type 
            => SpawnerType.NPC_ENEMY;
        public virtual NPCEnemyType EnemyType 
            => NPCEnemyType.TEST;

#if TEST_ENEMY_SPAWN
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Create();
            }
        }
#endif

        protected virtual ItemPool GetPrefabFromDataSet()
        {
            ItemPool item = CastleRushConfig.GetNPCEnemyPrefab(EnemyType);
            SetItemPrefab(item);
            return item;
        }

        public virtual NPCEnemy Create(Transform transform = null)
        {
            GetPrefabFromDataSet();

            // Set spawn point at the first position point of the waypoint array
            SetSpawnPoint(PathWaypoints.Points[0].position);

            return (NPCEnemy)Pool.Get();
        }
    }
}
