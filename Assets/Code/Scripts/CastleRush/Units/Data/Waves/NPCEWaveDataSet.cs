using CastleRush.Units;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Data
{
    [CreateAssetMenu(fileName = "NewEnemyWaveDataSet",
            menuName = "Castle Rush/Wave Sets/New NPC Enemy Wave Data Set",
            order = 1)]
    public class NPCEWaveDataSet : ScriptableObject
    {
        [SerializeField] int Level_ID; // for design reference and balance purposes

        //Start Countdown
        public float StartCountDownTime = 6f;

        //Time beetween units
        public float CooldownTimeBetweenUnits = 2f;

        [SerializeField] public List<NPCEWaveUnit> m_npceWaveUnits;
        public List<NPCEWaveUnit> NPCEWaveUnits 
        { 
            get
            {
                if(null == m_npceWaveUnits)
                    m_npceWaveUnits = new List<NPCEWaveUnit>();

                return m_npceWaveUnits;
            }
        }

        public NPCEnemyStats GetNPCEWaveUnitStats(int id)
        {
            int totalUnits = NPCEWaveUnits.Count;
            
            if (totalUnits < 1)
                return null;

            foreach (NPCEWaveUnit unit in NPCEWaveUnits)
            {
                if (id == unit.ID)
                    return unit.Stats;
            }

            return null;
        }

    }

    [Serializable]
    public class NPCEWaveUnit
    {
        [Header("Tracking ID")]
        public int ID; // for design reference and balance purposes

        [Header("Enemy Stats")]
        public NPCEnemyStats Stats;
    }
}