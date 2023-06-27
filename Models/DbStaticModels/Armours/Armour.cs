using ArmyProjectSecond.Models.DbStaticModels.MagicItems;
using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.Armours;

public class Armour
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<EqupmentOption> Options { get; set; }
    public List<MagicArmour> MagicUpgrades { get; set; }
}