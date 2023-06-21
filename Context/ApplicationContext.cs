using ArmyProjectSecondTry.Models;
using ArmyProjectSecondTry.Models.MagicItems;
using ArmyProjectSecondTry.Models.Options;
using ArmyProjectSecondTry.Models.Units;
using ArmyProjectSecondTry.Models.UnitsCategories;
using ArmyProjectSecondTry.Models.Weapons;
using Microsoft.EntityFrameworkCore;

namespace ArmyProjectSecondTry.Context;

public class ApplicationContext : DbContext
{
    public DbSet<MagicItem> MagicItems { get; set; } = null!;
    public DbSet<MagicWeapon> MagicWeapons { get; set; } = null!;
    public DbSet<BaseWeapon> Weapons { get; set; } = null!;
    public DbSet<CloseCombatWeapon> CloseCombatWeapons { get; set; } = null!;
    public DbSet<RangeWeapon> RangeWeapons { get; set; } = null!;

    public DbSet<Fraction> Fractions { get; set; } = null!;
    public DbSet<UnitCategorie> Categories { get; set; } = null!;

    public DbSet<BaseUnit> Units { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<MultiModelUnit> MultiModelUnits { get; set; } = null!;

    public DbSet<BaseOption> Options { get; set; } = null!;
    public DbSet<WeaponOption> WeaponOptions { get; set; } = null!;
    public DbSet<MountineOption> Mountines { get; set; } = null!;
 
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=armyProjectDb;Username=postgres;Password=panzer117");
    }
}