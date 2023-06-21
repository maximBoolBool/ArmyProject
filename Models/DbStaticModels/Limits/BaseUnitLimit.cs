using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecondTry.Models.Units;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArmyProjectSecondTry.Models;

public class BaseUnitLimit
{
    public int Id { get; set; }
    [ForeignKey("LimitedUnit")]
    public int BaseUnitId { get; set; }
    [ForeignKey("LimitedFraction")]
    public int FractionId { get; set; }
    
    public Fraction LimitedFraction { get; set; }
    public BaseUnit LimitedUnit { get; set; }
}