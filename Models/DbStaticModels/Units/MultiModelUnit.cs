using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.DbStaticModels.Units;

public class MultiModelUnit : BaseUnit
{
    public int PointCostPerAdditionalFigure { get; set; }
    public int StartUnitSize { get; set; }
    public int MaxUnitSize { get; set; }
    public List<CommandGroupUpgradeOption> CommandGroupUpgradeOptions { get; set; }
}