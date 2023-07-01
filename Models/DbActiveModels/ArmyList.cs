using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels;

namespace ArmyProjectSecond.Models.DbActiveModels;

public class ArmyList
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Fraction")]
    public string Fractionid { get; set; }
    
    public List<Unit> ArmyUnits { get; set; }
    public Fraction FractionId { get; set; }
}