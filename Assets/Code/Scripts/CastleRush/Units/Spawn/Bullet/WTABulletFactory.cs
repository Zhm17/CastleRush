using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTABulletFactory : Singleton<WTABulletFactory>
    {
        public SpawnerType Type => SpawnerType.WT_BULLET;

        // WT Ammo Units
        [Header("Transform parents")]
        [SerializeField] private Transform[] SpawnerParentsT;

        // WT Ammo Spawners
        private WTAmmoSpawner m_wtAmmoSpawner;
        private WTAmmoSpawner DefaultAmmoSpawner
        {
            get
            {
                if(null == m_wtAmmoSpawner)
                {
                    m_wtAmmoSpawner = gameObject.AddComponent<WTAmmoSpawner>();
                    m_wtAmmoSpawner.SetSpawnerParent(SpawnerParentsT[0]);
                }
                return m_wtAmmoSpawner;
            }
        }

        private WTAArrowSpawner m_wtaArrowSpawner;
        private WTAArrowSpawner ArrowSpawner
        {
            get
            {
                if(null == m_wtaArrowSpawner)
                {
                    m_wtaArrowSpawner = gameObject.AddComponent<WTAArrowSpawner>();
                    m_wtaArrowSpawner.SetSpawnerParent(SpawnerParentsT[1]);
                }
                return m_wtaArrowSpawner;
            }
        }

        private WTABulletGunSpawner m_wtaBulletGunSpawner;
        private WTABulletGunSpawner BulletGunSpawner
        {
            get
            {
                if(null == m_wtaBulletGunSpawner)
                {
                    m_wtaBulletGunSpawner = gameObject.AddComponent<WTABulletGunSpawner>();
                    m_wtaBulletGunSpawner.SetSpawnerParent(SpawnerParentsT[2]);
                }
                return m_wtaBulletGunSpawner;
            }
        }

        private WTACannonBallSpawner m_wtaCannonBallSpawner;
        private WTACannonBallSpawner CannonBallSpawner
        {
            get
            {
                if(null == m_wtaCannonBallSpawner)
                {
                    m_wtaCannonBallSpawner = gameObject.AddComponent<WTACannonBallSpawner>();
                    m_wtaBulletGunSpawner.SetSpawnerParent(SpawnerParentsT[3]);
                }
                return m_wtaCannonBallSpawner;
            }
        }

        protected override void Init()
        {

        }

        public virtual WTAmmo CreateNSet(WTAmmoType ammoType, Vector3 position)
        {
            WTAmmo newBullet = null;

            switch (ammoType)
            {
                case WTAmmoType.DEFAULT_AMMO:
                    newBullet = DefaultAmmoSpawner.Create(position);
                    break;
                case WTAmmoType.ARROW:
                    newBullet = ArrowSpawner.Create(position);
                    break;
                case WTAmmoType.BULLET_GUN:
                    newBullet = BulletGunSpawner.Create(position);
                    break;
                case WTAmmoType.CANNON_BALL:
                    newBullet = CannonBallSpawner.Create(position);
                    break;
            }

            return newBullet;
        }
    }
}
