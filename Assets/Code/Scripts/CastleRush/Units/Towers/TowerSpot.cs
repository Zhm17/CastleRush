using UnityEngine;

namespace CastleRush.Units
{
    public class TowerSpot : MonoBehaviour
    {
        [SerializeField] private Transform m_spawnPosition;
        public Transform SpawnPostion 
            => m_spawnPosition;

        [Header("Turrets")]
        [SerializeField] private WeaponTurret m_turret = null;
        public WeaponTurret Turret 
            => m_turret;
        public void SetTurret(WeaponTurret turret)
        {
            m_turret = turret;
            m_turret.transform.position = SpawnPostion.position;
        }
    }
}
