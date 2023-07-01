using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Option;

public class CommandGroupUpgradeOption
{
    public int Id { get; set; }
    public string UpgradeName { get; set; }
    public int UpgradeCoast { get; set; }

    [ForeignKey("ParrentUpgradeOption")]
    public int? ParrentUpgradeOptionId { get; set; }
    
    public CommandGroupUpgradeOption ParrentUpgradeOption { get; set; }
    public List<CommandGroupUpgradeOption> ChildUpgrades { get; set; }
    public List<MultiModelUnit> Units { get; set; }
}