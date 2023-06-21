using ArmyProjectSecondTry.Models.Weapons;

namespace ArmyProjectSecondTry.Models.MagicItems;

public class MagicWeapon : MagicItem
{
    public List<BaseWeapon> WeaponsAsCanBeUpgrade { get; set; } = new();
}