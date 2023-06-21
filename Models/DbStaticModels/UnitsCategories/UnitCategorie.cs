namespace ArmyProjectSecondTry.Models.UnitsCategories;

public class UnitCategorie
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int FractionId { get; set; }
    public int? Limit { get; set; }
        
    public Fraction Fraction { get; set; }
}