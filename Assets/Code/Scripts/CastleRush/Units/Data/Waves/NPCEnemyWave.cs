using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Data
{
    [CreateAssetMenu(fileName = "NewEnemyWaveSet",
            menuName = "Castle Rush/Wave Sets/New NPC Enemy Wave Set",
            order = 1)]
    public class NPCEnemyWave : ScriptableObject
    {
        [SerializeField] int ID; // for design reference and balance purposes

        //TODO Add Start Countdown
        public float StartCountDownTime = 6f;

        //TODO Add Time beetween units
        public float CooldownTimeBetweenUnits = 2f;
        
        [SerializeField] public List<NPCEnemyWaveUnit> EnemyWave;
    }

    [System.Serializable]
    public class NPCEnemyWaveUnit
    {
        [Header("Tracking ID")]
        public int ID; // for design reference and balance purposes

        [Header("Enemy Stats")]
        public Units.EnemyStats Stats;
    }
}
