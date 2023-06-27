using ArmyProjectSecond.Models.Armours;
using ArmyProjectSecond.Models.DbStaticModels.MagicItems;
using ArmyProjectSecond.Models.DbStaticModels.ManyToMany;
using ArmyProjectSecond.Models.DbStaticModels.Option;
using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecond.Models.DbStaticModels.Weapon;
using Microsoft.EntityFrameworkCore;

namespace ArmyProjectSecondTry.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<MultiModelUnit> MultiModelUnits { get; set; } = null!;
    
    public DbSet<RangeWeapon> RangeWeapons { get; set; } = null!;
    public DbSet<Armour> Armours { get; set; } = null!;
    public DbSet<CloseCombatWeapon> CloseCombatWeapons { get; set; } = null!;
    public DbSet<EqupmentOption> WeaponOptions { get; set; } = null!;
    
    public DbSet<ArmourToOption> ArmourToOptions { get; set; } = null!;
    public DbSet<CloseCombatWeaponToOption> CloseCombatWeaponToOptions { get; set; } = null!;
    public DbSet<RangeWeaponToOption> RangeWeaponToOptions { get; set; } = null!;
    public DbSet<CloseCombatWeaponToMagicUpgrade> CloseCombatWeaponToMagicUpgrades { get; set; } = null!;
    public DbSet<RangeWeaponToMagicUpgade> RangeWeaponToMagicUpgades { get; set; } = null!;
    public DbSet<ArmourToMagicUpgrade> ArmourToMagicUpgrades { get; set; } = null!;
    public DbSet<MountOption> MountOptions { get; set; } = null!;

    public DbSet<MagicArmour> MagicArmours { get; set; }
    public DbSet<MagicWeaponUpgrade> MagicWeaponUpgrades { get; set; }
    
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=armyProjectDb;Username=postgres;Password=panzer117");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateManyToManyConnection(modelBuilder);
        StartValues(modelBuilder);
    }

    private void CreateManyToManyConnection(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EqupmentOption>()
            .HasMany(eqOpt => eqOpt.CloseCombatWeapons)
            .WithMany(weapon => weapon.Options)
            .UsingEntity<CloseCombatWeaponToOption>(j => j.ToTable("CloseCombatWeaponToOptions"));
        
        modelBuilder.Entity<EqupmentOption>()
            .HasMany(eqOpt => eqOpt.RangeWeapons)
            .WithMany(weapon => weapon.Options)
            .UsingEntity<RangeWeaponToOption>(j => j.ToTable("RangeWeaponToOptions"));

        modelBuilder.Entity<EqupmentOption>()
            .HasMany(eqOpt => eqOpt.Armours)
            .WithMany(armour => armour.Options)
            .UsingEntity<ArmourToOption>(j => j.ToTable("ArmourToOptions"));

        modelBuilder.Entity<CloseCombatWeapon>()
            .HasMany(closeCombatWeapon => closeCombatWeapon.MagicUpgrades)
            .WithMany(upgrade => upgrade.CloseCombatWeapons)
            .UsingEntity<CloseCombatWeaponToMagicUpgrade>(t => t.ToTable("CloseCombatWeaponToMagicUpgrades"));

        modelBuilder.Entity<RangeWeapon>()
            .HasMany(rangeWeapon => rangeWeapon.MagicWeaponUpgrades)
            .WithMany(magicWeaponUpgrades => magicWeaponUpgrades.RangeWeapons)
            .UsingEntity<RangeWeaponToMagicUpgade>(t => t.ToTable("RangeWeaponToMagicUpgades"));

        modelBuilder.Entity<Armour>()
            .HasMany(armour => armour.MagicUpgrades)
            .WithMany(magicArmour => magicArmour.Armours)
            .UsingEntity<ArmourToMagicUpgrade>(t => t.ToTable("ArmourToMagicUpgrades"));
    }
    private void StartValues(ModelBuilder modelBuilder)
    {
        
    }
}