using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Categories;

namespace ArmyProjectSecond.Models.DbActiveModels;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPointCoast { get; set; }
    [ForeignKey("Categorie")]
    public int CategorieId { get; set; }
    
    public Categorie Categorie { get; set; }
    public List<UnitActiveOption> UnitCurrentOptions { get; set; }
}