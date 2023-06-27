using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecondTry.Context;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    BaseUnit? firstUnit = await db.MultiModelUnits
        .Include(unit => unit.UnitOptions)
        .ThenInclude(opt => opt.CloseCombatWeapons)
        .FirstOrDefaultAsync();


    Console.WriteLine(firstUnit?.Name);

    foreach (var option in firstUnit.UnitOptions)
    {
        Console.WriteLine($"{option.OptionCoast}");
        foreach (var closeCombatWeapon in option.CloseCombatWeapons)
        {
            Console.WriteLine($"{closeCombatWeapon.Name}--{closeCombatWeapon.Description}");
        }
    }
}