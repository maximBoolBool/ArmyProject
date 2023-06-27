using ArmyProjectSecond.Models.DbStaticModels.Weapon;

namespace ArmyProjectSecond.Models.DbStaticModels.Option;

public class WeaponOption
{
    public int Id { get; set; }
    public List<CloseCombatWeapon> Weapons { get; set; }
}