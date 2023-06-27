using ArmyProjectSecond.Models.Armours;
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
    }
    private void StartValues(ModelBuilder modelBuilder)
    {
        MultiModelUnit heavyInfantry = new() {
            Id = 1,
            Name = "Heavy Infantry",
            StartPointCoast = 140,
        };
        CloseCombatWeapon halebard = new() {
            Id = 1,
            Name = "Halebard",
            Description = "Halebard Description",
        };
        CloseCombatWeapon spear = new() {
            Id = 2,
            Name = "spear",
            Description = "Spear Description"
        };
        EqupmentOption option = new() {
            Id = 1,
            UnitId = 1,
            OptionCoast = 1,
        };
        EqupmentOption spearOption = new() {
            Id = 2,
            UnitId = 1,
            OptionCoast = 1,
        };
        CloseCombatWeaponToOption ccWto = new() {
            CloseCombatWeaponId = 1,
            EqupmentOptionId = 1,
        };
        CloseCombatWeaponToOption ccWto2 = new() {
            CloseCombatWeaponId = 2,
            EqupmentOptionId = 2,
        };


        
        
        modelBuilder.Entity<MultiModelUnit>().HasData(heavyInfantry);
        modelBuilder.Entity<EqupmentOption>().HasData(option , spearOption);
        modelBuilder.Entity<CloseCombatWeapon>().HasData(halebard , spear);
        modelBuilder.Entity<CloseCombatWeaponToOption>().HasData(ccWto , ccWto2);
    }
}