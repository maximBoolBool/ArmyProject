using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.DbStaticModels.Units;
public abstract class BaseUnit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StartPointCoast { get; set; }
    
    public List<EqupmentOption> UnitOptions { get; set; }
}