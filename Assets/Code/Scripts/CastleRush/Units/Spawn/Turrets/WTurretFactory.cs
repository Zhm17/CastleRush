using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTurretFactory : Singleton<WTurretFactory>
    {
        public SpawnerType Type => SpawnerType.WEAPON_TURRET;

        // WTurrets Units
        [Header("Transform parents")]
        [SerializeField] private Transform[] SpawnerParentsT;


        // WTurrets Spawners
        private WTurretSpawner m_wTurretSpawner;
        private WTurretSpawner DefaultTurretSpawner
        {
            get
            {
                if (null == m_wTurretSpawner)
                {
                    m_wTurretSpawner = gameObject.AddComponent<WTurretSpawner>();
                    m_wTurretSpawner.SetSpawnerParent(SpawnerParentsT[0]);
                }
                return m_wTurretSpawner;
            }
        }

        private WTCrossbowSpawner m_wtCrossbowSpawner;
        private WTCrossbowSpawner CrossbowSpawner
        {
            get
            {
                if(null == m_wtCrossbowSpawner)
                {
                    m_wtCrossbowSpawner = gameObject.AddComponent<WTCrossbowSpawner>();
                    m_wtCrossbowSpawner.SetSpawnerParent(SpawnerParentsT[1]);
                }
                return m_wtCrossbowSpawner;
            }
        }

        private WTMachineGunSpawner m_wtMachineGunSpawner;
        private WTMachineGunSpawner MachineGunSpawner
        {
            get
            {
                if(null == m_wtMachineGunSpawner)
                {
                    m_wtMachineGunSpawner = gameObject.AddComponent<WTMachineGunSpawner>();
                    m_wtMachineGunSpawner.SetSpawnerParent(SpawnerParentsT[2]);
                }
                return m_wtMachineGunSpawner; 
            }
        }

        private WTCannonSpawner m_wtCannonSpawner;
        private WTCannonSpawner CannonSpawner
        {
            get
            {
                if(null == m_wtCannonSpawner)
                {
                    m_wtCannonSpawner = gameObject.AddComponent<WTCannonSpawner>();
                    m_wtCannonSpawner.SetSpawnerParent(SpawnerParentsT[3]);
                }
                return m_wtCannonSpawner;
            }
        }

        protected override void Init()
        {

        }

        public virtual WTurret CreateNSet(WTurretType turretType, Vector3 position)
        {
            WTurret newTurret = null;

            switch (turretType)
            {
                case WTurretType.DEFAULT:
                    newTurret = DefaultTurretSpawner.Create(position);
                    break;
                case WTurretType.CROSSBOW:
                    newTurret = CrossbowSpawner.Create(position);
                    break;
                case WTurretType.MACHINE_GUN:
                    newTurret = MachineGunSpawner.Create(position);
                    break;
                case WTurretType.CANNON:
                    newTurret = CannonSpawner.Create(position);
                    break;
            }

            return newTurret;
        }
    }
}
