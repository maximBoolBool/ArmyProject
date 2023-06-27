using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Categories;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Option;
public class MountOption
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PointCoast { get; set; }
    
    [ForeignKey("Owner")]
    public int UnitId { get; set; }
    [ForeignKey("Categorie")]
    public int? CategorieId { get; set; } 
        
    public Categorie Categorie { get; set; }
    public Character Owner { get; set; }
}