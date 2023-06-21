using ArmyProjectSecondTry.Models.Units;
using ArmyProjectSecondTry.Models.UnitsCategories;

namespace ArmyProjectSecondTry.Models;

public class Fraction
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<BaseUnit> FractionUnits { get; set; }
    public List<BaseUnitLimit> FractionLimits { get; set; }
    public List<UnitCategorie> FractionCategories { get; set; }
}