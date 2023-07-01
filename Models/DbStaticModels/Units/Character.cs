using ArmyProjectSecond.Models.DbStaticModels.Limits;
using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.DbStaticModels.Units;

public class Character : BaseUnit
{
    public List<MountOption> CharacterMountOPtions { get; set; }
    public List<CharacterMagicPointCoastLimit> MagicLimits { get; set; }
}