using CastleRush.Units;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Data
{
    [CreateAssetMenu(fileName = "NewEnemyWaveDataSet",
            menuName = "Castle Rush/Wave Sets/New NPC Enemy Wave Data Set",
            order = 1)]
    public class NPCEnemyWaveDataSet : ScriptableObject
    {
        [SerializeField] int Level_ID; // for design reference and balance purposes

        //Start Countdown
        public float StartCountDownTime = 6f;

        //Time beetween units
        public float CooldownTimeBetweenUnits = 2f;

        [SerializeField] public static List<NPCEnemyWaveUnit> m_npceWaveUnits;
        public List<NPCEnemyWaveUnit> NPCEWaveUnits 
        { 
            get
            {
                if(null == m_npceWaveUnits)
                    m_npceWaveUnits = new List<NPCEnemyWaveUnit>();
                return m_npceWaveUnits;
            }
        }

        public NPCEnemyStats GetNPCEnemyWaveUnitStats(int id)
        {
            int totalUnits = NPCEWaveUnits.Count;
            
            if (totalUnits < 1)
                return null;

            int index = 0;
            while (index < totalUnits)
            {
                if (id == NPCEWaveUnits[index].ID)
                    return NPCEWaveUnits[index].Stats;
                
                index++;
            }

            return null;
        }

    }

    [Serializable]
    public class NPCEnemyWaveUnit
    {
        [Header("Tracking ID")]
        public int ID; // for design reference and balance purposes

        [Header("Enemy Stats")]
        public NPCEnemyStats Stats;
    }
}