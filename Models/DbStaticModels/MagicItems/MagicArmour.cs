namespace ArmyProjectSecondTry.Models.MagicItems;

public class MagicArmour : MagicItem
{
    public List<ArmourType> ArmourTypeCanBeUpgrade { get; set; } = new();
}