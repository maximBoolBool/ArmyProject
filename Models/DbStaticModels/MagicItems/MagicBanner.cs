using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Categories;
using ArmyProjectSecond.Models.DbStaticModels.MagicItems;

public class MagicBanner : MagicItem
{
    [ForeignKey("Categorie")]
    public int CategorieId { get; set; }
    
    public Categorie Categorie { get; set; }
}