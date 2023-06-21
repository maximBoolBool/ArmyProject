using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyProjectSecondTry.Models.Options;

public class ArmourOptions
{
    public int Id { get; set; }
    [ForeignKey("Armour")]
    public int ArmourId { get; set; }
    
    public ArmourType Armour { get; set; }
}