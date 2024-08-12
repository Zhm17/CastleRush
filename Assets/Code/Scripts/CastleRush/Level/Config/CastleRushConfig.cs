using CastleRush.Units;
using UnityEngine;

namespace CastleRush.Data.Config
{
    public static class CastleRushConfig
    {
        #region WAVE DATA

        // NPC Enemy Waves Libs
        public static NPCEWaveDataLib NPCEWLib =
           (NPCEWaveDataLib)
                Resources.Load("Data/Level/Waves/CastleRushWaveDataLib",
                    typeof(NPCEWaveDataLib));

        public static NPCEWaveDataSet GetNPCEWaveDataSet(int index)
        {
            if (null == NPCEWLib || 
                index >= NPCEWLib.Lib.Count ||
                index < 0)
                    return null;

            return NPCEWLib.Lib[index];
        }

        #endregion

        #region PREFABS

        public static PrefabLibs PrefabLib =
            (PrefabLibs)
            Resources.Load("Data/Lib/CastleRushPrefabLibs",
                typeof(PrefabLibs));

        public static NPCEnemy GetNPCEnemyPrefab(NPCEnemyType enemyType)
        {
            if (null == PrefabLib.NPCEnemyPrefabLib)
                return null;

            foreach (NPCEnemyDataField enemy in PrefabLib.NPCEnemyPrefabLib)
            {
                if (enemyType == enemy.NPCEnemyPrefab.Type)
                    return enemy.NPCEnemyPrefab;
            }

            return null;
        }

        public static WTAmmo GetWTAmmoPrefab(WTAmmoType ammoType)
        {
            if (null == PrefabLib.WTABulletsPrefabLib)
                return null;

            foreach (WTABulletDataField bullet in PrefabLib.WTABulletsPrefabLib)
            {
                if (ammoType == bullet.WTABulletPrefab.AmmoType)
                    return bullet.WTABulletPrefab;
            }

            return null;
        }

        public static WTurret GetTurretPrefab(WTurretType turretType) 
        {
            if (null == PrefabLib.WTurretPrefabLib)
                return null;

            foreach(WTurretDataField turret in PrefabLib.WTurretPrefabLib)
            {
                if(turretType == turret.WTurretPrefab.Type)
                    return turret.WTurretPrefab;
            }

            return null; 
        }

        #endregion
    }
}
