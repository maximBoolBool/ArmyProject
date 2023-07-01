using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Categories;
using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.DbStaticModels.Units;
public abstract class BaseUnit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StartPointCoast { get; set; }
    [ForeignKey("Categorie")]
    public int CategorieId { get; set; }
    [ForeignKey("Fraction")]
    public int FractionId { get; set; }
    
    public Fraction Fraction { get; set; }
    public Categorie Categorie { get; set; }
    public List<EqupmentOption> UnitOptions { get; set; }
}