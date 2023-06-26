using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecondTry.Models.UnitsCategories;

namespace ArmyProjectSecondTry.Models.Options;

public class MountineOption : BaseOption
{
    public string MountinName { get; set; }
    [ForeignKey("Categorie")]
    public int UnitCategorie { get; set; } 
    
    public UnitCategorie Categorie { get; set; }
}