using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecondTry.Models.Units;

namespace ArmyProjectSecondTry.Models.Options;

public class BaseOption
{
    public int Id { get; set; }
    /*[ForeignKey("Unit")]
    public  int? UnitId { get; set; }*/
    public int PointCost { get; set; }
    /*
    public BaseUnit Unit { get; set; }*/
}