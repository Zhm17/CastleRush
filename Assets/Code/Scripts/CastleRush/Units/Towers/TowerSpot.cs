using UnityEngine;

namespace CastleRush.Units
{
    public class TowerSpot : MonoBehaviour
    {
        [SerializeField] private Transform m_turretSpawnPosition;
        public Transform TurretSpawnPosition 
            => m_turretSpawnPosition;

        [Header("Turrets")]
        [SerializeField] private WTurret m_turret = null;
        public WTurret Turret 
            => m_turret;

        public void SetTurret(WTurret turret)
        {
            m_turret = turret;
            m_turret.transform.position = TurretSpawnPosition.position;
        }
    }
}
