using CastleRush.Data.Config;
using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTAmmoSpawner : ObjectPoolController, IFactory<WTAmmo>
    {
        public virtual SpawnerType Type => SpawnerType.WEAPON_TURRET_AMMO;
        public virtual WTAmmoType AmmoType => WTAmmoType.DEFAULT_AMMO;

        [SerializeField] private Transform m_turretSpawnPosition;
        public Transform TurretSpawnPostion
            => m_turretSpawnPosition;
        public void SetTurretSpawnPosition(Transform transformSpawnPosition)
            => m_turretSpawnPosition = transformSpawnPosition;

        protected virtual ItemPool GetPrefabFromDataSet()
        {
            ItemPool item = CastleRushConfig.GetWTAmmoPrefab(AmmoType);
            SetItemPrefab(item);
            return item;
        }

        public virtual WTAmmo Create(Transform transform = null)
        {
            GetPrefabFromDataSet();
            
            if(null != transform)
                SetSpawnPoint(transform.position);

            return (WTAmmo)Pool.Get();
        }
    }
}
