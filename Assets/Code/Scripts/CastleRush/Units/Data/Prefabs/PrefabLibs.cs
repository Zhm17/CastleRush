namespace CastleRush.Data
{
    [UnityEngine.CreateAssetMenu(fileName = "NewCastleRushPrefabLibs",
            menuName = "Castle Rush/Prefabs/New Prefab Libs",
            order = 1)]
   
    public class PrefabLibs : UnityEngine.ScriptableObject
    {
        [UnityEngine.SerializeField]
        public int LibID = 1;

        // TODO Separate in different prefab libraries
        
        // TODO Add SFX Lib

        // TODO Add VFX Lib

        // TODO Add Bullets Lib

        // TODO Add Towers Lib

        // TODO Add Turrets Lib

        [UnityEngine.Header("NPC Enemies")]
        [UnityEngine.SerializeField] 
        public System.Collections.Generic.List<NPCEnemyField> NPCEnemyPrefabLib;

    }
}
