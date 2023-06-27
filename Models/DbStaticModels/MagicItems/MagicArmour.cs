using ArmyProjectSecond.Models.Armours;

namespace ArmyProjectSecond.Models.DbStaticModels.MagicItems;

public class MagicArmour : MagicItem
{
    public List<Armour> Armours { get; set; }
}