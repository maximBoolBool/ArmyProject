using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Limits;

public class CharacterMagicPointCoastLimit
{
    public int Id { get; set; }
    public int Limit { get; set; }
    [ForeignKey("Character")]
    public int CharacterId { get; set; }

    public Character Character { get; set; }
}