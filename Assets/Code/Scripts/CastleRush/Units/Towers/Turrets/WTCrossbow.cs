namespace CastleRush.Units
{
    public class WTCrossbow : WTurret
    {
        public override WTurretType Type 
            => WTurretType.CROSSBOW;

        public override WTAmmoType AmmoType
            => WTAmmoType.ARROW;
    }
}
