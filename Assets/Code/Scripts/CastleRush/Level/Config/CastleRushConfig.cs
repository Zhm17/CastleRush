using CastleRush.Units;
using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Data.Config
{
    public static class CastleRushConfig
    {
        public static PrefabLibs PrefabLib =
            (PrefabLibs)
            Resources.Load("Data/Lib/CastleRushPrefabLibs",
                typeof(PrefabLibs));

        // NPC Enemy9 Waves Libs
        private static Dictionary<int, NPCEWaveDataSet> s_npcWavesLib;
        public static Dictionary<int, NPCEWaveDataSet> NPCEnemyWavesLib
        {
            get
            {
                if (null == s_npcWavesLib)
                    RefreshNPCEWaveList();
                return s_npcWavesLib;
            }
        }

        public static void RefreshNPCEWaveList()
        {
            s_npcWavesLib = new Dictionary<int, NPCEWaveDataSet>();
            foreach (NPCEWaveDataSet waveSet in
                        Resources.LoadAll<NPCEWaveDataSet>("Data/Level/Waves"))
                s_npcWavesLib.Add(s_npcWavesLib.Count + 1, waveSet);
        }




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

            return null; 
        }
    }
}
