namespace ArmyProjectSecond.Models.DbActiveModels;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPointCoast { get; set; }
    
    public List<UnitActiveOption> UnitCurrentOptions { get; set; }
}