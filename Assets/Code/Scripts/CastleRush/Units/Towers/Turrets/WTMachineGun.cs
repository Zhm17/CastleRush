namespace CastleRush.Units 
{ 
    public class WTMachineGun : WTurret
    {
        public override WTurretType Type 
            => WTurretType.MACHINE_GUN;

        public override WTAmmoType AmmoType
            => WTAmmoType.BULLET_GUN;
    }
}
