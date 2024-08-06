using CastleRush.Data.Config;
using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTAmmoSpawner : ObjectPoolController, IFactory<WTAmmo>
    {
        public virtual SpawnerType Type => SpawnerType.WT_BULLET;
        public virtual WTAmmoType AmmoType => WTAmmoType.DEFAULT_AMMO;


        protected virtual ItemPool GetPrefabFromDataSet()
        {
            ItemPool item = CastleRushConfig.GetWTAmmoPrefab(AmmoType);
            SetItemPrefab(item);
            return item;
        }

        public virtual WTAmmo Create(Vector3 position)
        {
            GetPrefabFromDataSet();
            
            SetSpawnPoint(position);

            return (WTAmmo) Pool.Get();
        }
    }
}
