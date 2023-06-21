using System.ComponentModel.DataAnnotations.Schema;

namespace ArmyProjectSecondTry.Models.Units;

public class MagicItemConstraint
{
    public int Id { get; set; }
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    public int MaxMagicItemPointCoast { get; set; }
    
   public Character Character { get; set; }
}