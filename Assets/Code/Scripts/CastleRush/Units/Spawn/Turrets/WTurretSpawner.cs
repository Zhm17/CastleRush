using Utils;
using UnityEngine;
using CastleRush.Data.Config;

namespace CastleRush.Units
{
    public class WTurretSpawner : ObjectPoolController, IFactory<WTurret>
    {
        public virtual SpawnerType Type 
            => SpawnerType.WEAPON_TURRET;
        public virtual WTurretType TurretType 
            => WTurretType.DEFAULT;
        

        protected virtual ItemPool GetPrefabFromDataSet()
        {
            ItemPool item = CastleRushConfig.GetTurretPrefab(TurretType);
            SetItemPrefab(item);
            return item;
        }

        public virtual WTurret Create(Vector3 position)
        {
            GetPrefabFromDataSet();

            SetSpawnPoint(position);

            return (WTurret) Pool.Get();
        }
    }
}