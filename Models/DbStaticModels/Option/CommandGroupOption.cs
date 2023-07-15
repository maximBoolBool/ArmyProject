using ArmyProjectSecond.Models.DbStaticModels.Units;

namespace ArmyProjectSecond.Models.DbStaticModels.Option;

public class CommandGroupOption
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int OptionPointCoast { get; set; }
    
    public CommandGroupOption? ParrentOption { get; set; }
    public List<CommandGroupOption>? ChildOptions { get; set; }
    public List<MultiModelUnit> Units { get; set; } 
}