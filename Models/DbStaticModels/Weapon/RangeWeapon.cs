using ArmyProjectSecond.Models.DbStaticModels.MagicItems;
using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.DbStaticModels.Weapon;

public class RangeWeapon : BaseWeapon
{
    public string Name { get; set; }
    public int Range { get; set; }
    public int Shots { get; set; }
    public string Strength { get; set; }
    public string ArmourPenetration { get; set; }
    public string AttackAttributes { get; set; }
    public string? Description { get; set; }
    public List<EqupmentOption> Options { get; set; }
    public List<MagicWeaponUpgrade> MagicWeaponUpgrades { get; set; }
}