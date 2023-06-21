using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyProjectSecondTry.Models.MagicItems;

public abstract class MagicItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointCost { get; set; }
    [ForeignKey("Fraction")]
    public int? FractionId { get; set; }
    
    public Fraction Fraction { get; set; }
}