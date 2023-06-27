using ArmyProjectSecond.Models.DbStaticModels.Weapon;

namespace ArmyProjectSecond.Models.DbStaticModels.MagicItems;

public class MagicWeaponUpgrade : MagicItem
{
    public List<CloseCombatWeapon> CloseCombatWeapons { get; set; }
    public List<RangeWeapon> RangeWeapons { get; set; }
}