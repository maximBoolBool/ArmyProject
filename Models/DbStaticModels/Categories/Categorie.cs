using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Categories;

public class Categorie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Limit { get; set; }
    
    [ForeignKey("Fraction")]
    public int FractionId { get; set; }
    
    public Fraction Fraction { get; set; }
    public List<BaseUnit> CategorieUnit { get; set; }
}