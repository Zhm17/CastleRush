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
        private static Dictionary<int, NPCEnemyWaveDataSet> s_npcWavesLib;
        public static Dictionary<int, NPCEnemyWaveDataSet> NPCEnemyWavesLib
        {
            get
            {
                if (null == s_npcWavesLib)
                    RefreshWaveList();
                return s_npcWavesLib;
            }
        }

        public static void RefreshWaveList()
        {
            s_npcWavesLib = new Dictionary<int, NPCEnemyWaveDataSet>();
            foreach (NPCEnemyWaveDataSet waveSet in
                        Resources.LoadAll<NPCEnemyWaveDataSet>("Data/Level/Waves"))
                s_npcWavesLib.Add(s_npcWavesLib.Count + 1, waveSet);
        }

        public static NPCEnemy GetNPCEnemyPrefab(NPCEnemyType enemyType)
        {
            if (null == PrefabLib.NPCEnemyPrefabLib) 
                return null;

            int index = 0;
            while ( index < PrefabLib.NPCEnemyPrefabLib.Count)
            {
                if( enemyType == PrefabLib.NPCEnemyPrefabLib[index].NPCEnemyPrefab.Type)
                {
                    return PrefabLib.NPCEnemyPrefabLib[index].NPCEnemyPrefab;
                }
                index++;
            }
            
            return null;
        }
    }
}
