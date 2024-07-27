namespace CastleRush.Data
{
    [System.Serializable]
    public class NPCEnemyField
    {
        [UnityEngine.Header("NPC Enemy Type")]
        public Units.EnemyType type;

        [UnityEngine.Header("NPC Enemy Subclass Prefab")]
        public Units.NPCEnemy NPCEnemyPrefab;
    }
}
