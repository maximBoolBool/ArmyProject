using System.ComponentModel.DataAnnotations.Schema;
namespace ArmyProjectSecond.Models.DbStaticModels.MagicItems;
public class MagicItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PointCoast { get; set; }
    public string Description { get; set; }
    
    [ForeignKey("Fraction")]
    public int? FractioId { get; set; }
 
    public Fraction? Fraction { get; set; }
}