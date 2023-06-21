using ArmyProjectSecondTry.Models.MagicItems;
using ArmyProjectSecondTry.Models.Options;

namespace ArmyProjectSecondTry.Models.Weapons;

public abstract class BaseWeapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<MagicWeapon> MagicUpgrade { get; set; } = new();
    public List<WeaponOption> WeaponOptions { get; set; } = new();
}