using ArmyProjectSecondTry.Models.Options;

namespace ArmyProjectSecondTry.Models.Units;

public class Character : BaseUnit
{
    public List<MagicItemConstraint> CharactersItemsConstraints { get; set; }
    public List<MountineOption> CharactersMountineOptions { get; set; }
    public List<ArmourOptions> CharactersArmourOptions { get; set; }
}