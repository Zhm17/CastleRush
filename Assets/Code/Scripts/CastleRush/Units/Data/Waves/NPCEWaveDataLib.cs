using System.Collections.Generic;
using UnityEngine;

namespace CastleRush.Data
{

    [CreateAssetMenu(fileName = "NewWaveDataLib",
            menuName = "Castle Rush/Wave Sets/New NPC Enemy Wave Data Lib",
            order = 1)]

    public class NPCEWaveDataLib : ScriptableObject
    {
        // NPC Enemy Waves Libs
        [Header("NPCEnemy Wave Lib")]
        [SerializeField] public List<NPCEWaveDataSet> Lib;
    }
}
