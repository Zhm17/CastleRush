using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class EnemySpawner : ObjectPoolController, IFactory<NPCEnemy>
    {

        public SpawnerType Type => SpawnerType.DEFAULT;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Create();
            } 
        }

        public NPCEnemy Create()
        {
            SetSpawnPoint(PathWaypoints.Points[0].position);

            NPCEnemy newNPCEnemy = (NPCEnemy) Pool.Get();
            return newNPCEnemy;
        }
    }
}
