using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecondTry.Context;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{

    BaseUnit? heavyInfantry = await db.MultiModelUnits
        .Include(character => character.UnitOptions)
            .ThenInclude(option => option.RangeWeapons )
        .FirstOrDefaultAsync(character => character.Name.Equals("Reiters"));

    foreach (var option in heavyInfantry.UnitOptions)
    {
        Console.WriteLine($"{option.Id} {option.OptionCoast}");
        foreach (var rangeWeapon in option.RangeWeapons)
        {
            Console.WriteLine($"{rangeWeapon.Name} {rangeWeapon.Description}");
        }
    }


}