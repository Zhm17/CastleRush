using UnityEngine;
using System.Collections.Generic;

namespace CastleRush.Data
{
    [CreateAssetMenu(fileName = "NewCastleRushPrefabLibs",
            menuName = "Castle Rush/Prefabs/New Prefab Libs",
            order = 1)]
   
    public class PrefabLibs : ScriptableObject
    {
        [SerializeField]
        public int LibID = 1;

        // Separate in different prefab libraries

        // TODO Add SFX Lib

        // TODO Add VFX Lib


        // TOWERS / TURRETS / AMMO - BULLETS
        //Add Turrets Lib
        [Header("Weapon Turrets")]
        [SerializeField]
        public List<WTurretDataField> WTurretPrefabLib;

        [Header("Weapon Turret Ammo / Bullets")]
        [SerializeField]
        public List<WTABulletDataField> WTABulletsPrefabLib;



        // NPC Enemies
        [Header("NPC Enemies")]
        [SerializeField] 
        public List<NPCEnemyDataField> NPCEnemyPrefabLib;

    }
}
