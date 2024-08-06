namespace CastleRush.Units
{
    public class WTCannon : WTurret
    {
        public override WTurretType Type 
            => WTurretType.CANNON;

        public override WTAmmoType AmmoType
           => WTAmmoType.CANNON_BALL;
    }
}
