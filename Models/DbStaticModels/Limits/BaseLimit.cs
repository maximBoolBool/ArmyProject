using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Limits;

public abstract class BaseLimit
{
    public int Id { get; set; }
    [ForeignKey("Unit")]
    public int UnitId { get; set; }
    
    public BaseUnit Unit { get; set; }
}