using ArmyProjectSecond.Models.DbStaticModels.MagicItems;
using ArmyProjectSecond.Models.DbStaticModels.Option;
namespace ArmyProjectSecond.Models.DbStaticModels.Weapon;
public class CloseCombatWeapon :BaseWeapon
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<EqupmentOption> Options { get; set; }
    public List<MagicWeaponUpgrade> MagicUpgrades { get; set; }
}