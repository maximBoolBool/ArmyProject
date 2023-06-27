using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.Armours;
using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecond.Models.DbStaticModels.Weapon;
namespace ArmyProjectSecond.Models.DbStaticModels.Option;
public class EqupmentOption
{
    public int Id { get; set; }
    public int OptionCoast { get; set; }
    
    [ForeignKey("Unit")]
    public int UnitId { get; set; }  
    
    public BaseUnit Unit { get; set; }
    public List<CloseCombatWeapon> CloseCombatWeapons { get; set; }
    public List<RangeWeapon> RangeWeapons { get; set; }
    public List<Armour> Armours { get; set; }
}