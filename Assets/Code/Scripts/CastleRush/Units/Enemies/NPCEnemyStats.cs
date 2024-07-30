using UnityEngine;

namespace CastleRush.Units
{
    [System.Serializable]
    public class NPCEnemyStats
    {
        public NPCEnemyType type;

        //TODO Maybe add an State AWAKE, WALK, DEAD, FINISH

        //TODO Maybe add Status like FROZEN, POSIONED, PARALYZED, ...

        // Item Loop
        [Header("Item Pool")]
        public float lifeTime = 60f;

        // NPCEnemy
        [Header("Enemy")]
        public int damageValue = 1;

        // Health
        [Header("Health")]
        public int maxHealth = 3;

        // Navigation (Follow Waypoints)
        [Header("Navigation")]
        public float startWalkSpeed = 5f;
    }
}
