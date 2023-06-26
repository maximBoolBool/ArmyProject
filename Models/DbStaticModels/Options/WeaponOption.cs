using ArmyProjectSecondTry.Models.Weapons;

namespace ArmyProjectSecondTry.Models.Options;

public class WeaponOption : BaseOption
{
    public List<BaseWeapon> Weapons { get; set; }
}