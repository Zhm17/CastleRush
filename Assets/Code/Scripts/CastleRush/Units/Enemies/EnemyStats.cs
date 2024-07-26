namespace CastleRush.Units
{
    [System.Serializable]
    public class EnemyStats
    {
        public EnemyType type;

        public float lifeTime = 60f;

        //TODO Add Health

        //TODO Add Damage

        //TODO Maybe add an State AWAKE, WALK, DEAD, FINISH

        //TODO Maybe add Status like FROZEN, POSIONED, PARALYZED, ...

        public float startWalkSpeed = 5f;
    }
}
