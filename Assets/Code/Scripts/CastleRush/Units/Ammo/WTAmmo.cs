using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    public class WTAmmo : ItemPool
    {
        [SerializeField] public virtual WTAmmoType AmmoType
            => WTAmmoType.DEFAULT_AMMO ;

        //TODO Bullet Traject and Interaction
    }
}
