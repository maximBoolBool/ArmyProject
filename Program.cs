using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecondTry.Context;
using Microsoft.EntityFrameworkCore;

using ApplicationContext db = new ApplicationContext();


List<MultiModelUnit> units = await db.MultiModelUnits
    .Include(unit => unit.UnitCommandGroupOptions)
    .ToListAsync();


foreach (var unit in units)
{
    Console.WriteLine($"{unit.Name} {unit.StartPointCoast}");
    foreach (var commandGroup in unit.UnitCommandGroupOptions)
    {
        Console.WriteLine($"\t{commandGroup.Name} {commandGroup.OptionPointCoast}");
    }
}