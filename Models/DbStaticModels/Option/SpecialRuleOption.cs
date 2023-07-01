using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Option;

public class SpecialRuleOption
{
    public int Id { get; set; }
    public string SpecialRuleName { get; set; }
    public int PointCoast { get; set; }
    public string Description { get; set; }
    [ForeignKey("Unit")]
    public int UnitId { get; set; }
    
    public BaseUnit Unit { get; set; }
}