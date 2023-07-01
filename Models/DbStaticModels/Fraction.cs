using ArmyProjectSecond.Models.DbStaticModels.Categories;
using ArmyProjectSecond.Models.DbStaticModels.Limits;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels;

public class Fraction
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Categorie> Categories { get; set; }
    public List<ModelLimit> Limits { get; set; } 
    public List<BaseUnit> FractionUnits { get; set; }
}