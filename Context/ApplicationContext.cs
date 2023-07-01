using ArmyProjectSecond.Models.Armours;
using ArmyProjectSecond.Models.DbStaticModels;
using ArmyProjectSecond.Models.DbStaticModels.Categories;
using ArmyProjectSecond.Models.DbStaticModels.MagicItems;
using ArmyProjectSecond.Models.DbStaticModels.ManyToMany;
using ArmyProjectSecond.Models.DbStaticModels.Option;
using ArmyProjectSecond.Models.DbStaticModels.Units;
using ArmyProjectSecond.Models.DbStaticModels.Weapon;
using Microsoft.EntityFrameworkCore;

namespace ArmyProjectSecondTry.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Fraction> Fractions { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<MultiModelUnit> MultiModelUnits { get; set; } = null!;
    public DbSet<SingleModelUnit> SingleModelUnits { get; set; } = null!;
    public DbSet<Categorie> Categories { get; set; } = null!;
    
    public DbSet<RangeWeapon> RangeWeapons { get; set; } = null!;
    public DbSet<Armour> Armours { get; set; } = null!;
    public DbSet<CloseCombatWeapon> CloseCombatWeapons { get; set; } = null!;
    public DbSet<EqupmentOption> WeaponOptions { get; set; } = null!;
    public DbSet<CommandGroupUpgradeOption> CommandGroupUpgradeOptions { get; set; } = null!;
        
    public DbSet<ArmourToOption> ArmourToOptions { get; set; } = null!;
    public DbSet<CloseCombatWeaponToOption> CloseCombatWeaponToOptions { get; set; } = null!;
    public DbSet<RangeWeaponToOption> RangeWeaponToOptions { get; set; } = null!;
    public DbSet<CloseCombatWeaponToMagicUpgrade> CloseCombatWeaponToMagicUpgrades { get; set; } = null!;
    public DbSet<RangeWeaponToMagicUpgade> RangeWeaponToMagicUpgades { get; set; } = null!;
    public DbSet<ArmourToMagicUpgrade> ArmourToMagicUpgrades { get; set; } = null!;
    public DbSet<CommandGroupOptionToUnit> CommandGroupOptionToUnits { get; set; } = null!;
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
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=armyProjectDb;Username=postgres;Password=panzer117");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateManyToManyConnection(modelBuilder);
        /*
        AddFraction(modelBuilder);
        AddCategories(modelBuilder);
        AddCloseCombatWeapon(modelBuilder);
        AddRangeWeapon(modelBuilder);
        AddArmour(modelBuilder);
        AddCharacters(modelBuilder);
        AddCore(modelBuilder);
        AddSpecial(modelBuilder);
        AddImperialAuxiliaries(modelBuilder);
        AddImperilalArmoury(modelBuilder);
        AddSunnasFury(modelBuilder);*/
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

        modelBuilder.Entity<CommandGroupUpgradeOption>()
            .HasMany(commandGroupUpgradeOption => commandGroupUpgradeOption.Units)
            .WithMany(unit => unit.CommandGroupUpgradeOptions )
            .UsingEntity<CommandGroupOptionToUnit>(t => t.ToTable("CommandGroupOptionToUnits"));
    }
    private void AddFraction(ModelBuilder modelBuilder)
    {
        Fraction eos = new()
        {
            Id = 1,
            Name = "Empire Of Sonnstahl"
        };
        modelBuilder.Entity<Fraction>().HasData(eos);
    }
    private void AddCategories(ModelBuilder modelBuilder)
    {
        List<Categorie> empireCategories = new()
        {
            new()
            {
                Id = 1,
                Name = "Characters",
                Limit = 40,
                FractionId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Core",
                Limit = 25,
                FractionId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Special",
                FractionId = 1
            },
            new()
            {
                Id = 4,
                Name = "Imperial Auxiliaries",
                Limit = 35,
                FractionId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Imperial Armoury",
                Limit = 20,
                FractionId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Sunna's Fury",
                FractionId = 1,
                Limit = 30
            }
        };
        modelBuilder.Entity<Categorie>().HasData(empireCategories);
    }
    private void AddCharacters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
           new()
           {
               Id = 1,
               Name = "Marshal",
               StartPointCoast = 140,
               CategorieId = 1,
               FractionId = 1,
           },
           new()
           {
               Id = 2,
               Name = "Knight Commander",
               StartPointCoast = 175,
               CategorieId = 1,
               FractionId = 1,
           },
           new()
           {
               Id = 3,
               Name = "Wizard",
               StartPointCoast = 115,
               CategorieId = 1,
               FractionId = 1,
           },
           new()
           {
               Id = 4,
               Name = "Prelate",
               StartPointCoast = 145,
               CategorieId = 1,
               FractionId = 1,
           },
           new()
           {
               Id = 5,
               Name = "Artificer",
               StartPointCoast = 120,
               CategorieId = 1,
               FractionId = 1,
           },
           new()
           {
               Id = 6,
               Name = "Inquisitor",
               StartPointCoast = 95,
               CategorieId = 1,
               FractionId = 1,
           }
        });
    }
    private void AddCore(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MultiModelUnit>().HasData(new List<MultiModelUnit>()
        {
            new()
            {
                Id = 7,
                Name = "Heavy Infantry",
                StartPointCoast = 140,
                CategorieId = 2,
                FractionId = 1,
            },
            new()
            {
                Id = 8,
                Name = "Light Infantry",
                StartPointCoast = 130,
                CategorieId = 2,
                FractionId = 1,
            },
            new()
            {
                Id = 9,
                Name = "State Milita",
                StartPointCoast = 140,
                CategorieId = 2,
                FractionId = 1,
            },
            new()
            {
                Id   = 10,
                Name = "Electoral Cavalry",
                StartPointCoast = 155,
                CategorieId = 2,
                FractionId = 1,
            },
            new ()
            {
                Id = 11,
                Name = "Knightly Orders",
                StartPointCoast = 195,
                CategorieId = 2,
                FractionId = 1,
            }
        });
    }
    private void AddSpecial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MultiModelUnit>().HasData(new List<MultiModelUnit>() {
            new ()
            {
                Id = 12,
                Name = "Imperial Guard",
                CategorieId = 3,
                FractionId = 1,
                StartPointCoast = 170,
            },
            new ()
            {
                Id = 13,
                Name = "Knights of the Sun Griffon",
                CategorieId = 3,
                FractionId = 1,
                StartPointCoast = 275,
            }
        });
        modelBuilder.Entity<SingleModelUnit>().HasData(new SingleModelUnit(){
            Id = 14,
            Name = "Arcane Engine",
            CategorieId = 3,
            FractionId = 1,
            StartPointCoast = 255
        });
    }
    private void AddImperialAuxiliaries(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MultiModelUnit>().HasData(new List<MultiModelUnit>()
        {
            new ()
            {
                Id = 15,
                Name = "Imperial Rangers",
                CategorieId = 4,
                FractionId = 1,
                StartPointCoast = 90,
            },
            new()
            {
                Id = 16,
                Name = "Reiters",
                CategorieId = 4,
                FractionId = 1,
                StartPointCoast = 155
            }
        });
    }
    private void AddImperilalArmoury(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SingleModelUnit>().HasData(new SingleModelUnit()
        {
            Id = 17,
            Name = "Artillerry",
            CategorieId = 5,
            FractionId = 1,
            StartPointCoast = 150
        });
    }
    private void AddSunnasFury(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MultiModelUnit>().HasData(new MultiModelUnit()
        {
            Id = 18,
            Name = "Flagellants",
            CategorieId = 6,
            FractionId = 1,
            StartPointCoast = 185,
        });
        modelBuilder.Entity<SingleModelUnit>().HasData(new SingleModelUnit()
        {
           Id = 19,
           Name = "Steam Tank",
           CategorieId = 6,
           FractionId = 1,
           StartPointCoast = 450,
        });
    }
    private void AddArmour(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Armour>()
            .HasData(new List<Armour>()
            {
                new()
                {
                    Id = 1,
                    Name = "Light Armour",
                    Description = "+1 Armour",
                },
                new()
                {
                    Id = 2,
                    Name = "Heavy Armour",
                    Description = "+2 Armour",
                },
                new()
                {
                    Id = 3,
                    Name = "Plate Armour",
                    Description = "+3 Armour"
                },
                new()
                {
                    Id = 4,
                    Name = "Shield",
                    Description = "+1 Armour. While using a Two-Handed weapon, a Shield is only used when being attacked by Ranged Attacks"
                }
            });
    }
    private void AddCloseCombatWeapon(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CloseCombatWeapon>().HasData(new List<CloseCombatWeapon>() {
            new() {
                Id = 1,
                Name = "Great Weapon",
                Description = "Two-Handed. Attacks made with a Great Weapon gain +2 Strength, +2 Armour Penetration, and strike at Initiative Step 0 (regardless of the wielder’s Agility)"
            },
            new() {
                Id = 2,
                Name = "Halbred",
                Description = "Two-Handed. Attacks made with a Halberd gain +1Strength and +1 Armour Penetration",
            },
            new() {
                Id = 3,
                Name = "Hand Weapon",
                Description = "Gains Parry if model have Shield",
            },
            new() {
                Id = 4,
                Name = "Lance",
                Description = "Attacks made with a Lance and allocated towards models in the wielder’s Front Facing gain Devastating Charge (+2 Strength, +2 Armour Penetration). Infantry cannot use Lance"
            },
            new() {
                Id = 5,
                Name = "Light Lance",
                Description = "Attacks made with a Light Lance and allocated towards models in the wielder’s Front Facing gain Devastating Charge (+1 Strength, +1 Armour Penetration).Infantry cannot use Light Lances."
            },
            new() {
                Id = 6,
                Name = "Paried Weapons",
                Description = "Two-Handed. The wielder gains +1 Attack Value and +1 Offensive Skill when using Paired Weapons." +
                              "Attacks made with Paired Weapons ignore Parry (while Paired" + 
                              "Weapons are often modelled as two Hand Weapons," +
                              "they are considered a separate weapon category for rules purposes)."
            },
            new() {
                Id = 7,
                Name = "Spear",
                Description = "Attacks made with a Spear gain Fight in Extra Rank and +1 Armour Penetration. In addition, unless the"+
                "attacking model’s unit is Charging or is Engaged in any" +
                "Flank or Rear Facing, attacks made with a Spear gain +2"+
                "Agility and an additional +1 Armour Penetration in the"+
                "First Round of Combat. Only Infantry can use Spears."
            },
            new() {
                Id = 8,
                Name = "Cavalry Peak",
                Description = "Attacks made with this weapon gain +2 Armour Penetration"
            },
        });
    }
    private void AddRangeWeapon(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RangeWeapon>().HasData(new List<RangeWeapon>() {
                new() 
                {
                    Id = 1,
                    Name = "Bow",
                    Range = 24,
                    Shots = 1,
                    Strength = "3",
                    ArmourPenetration = "0",
                    AttackAttributes = "Volley Fire",
                },
                new()
                {
                    Id = 2,
                    Name = "Crossbow",
                    Range = 30,
                    Shots = 1,
                    Strength = "4",
                    ArmourPenetration = "1",
                    AttackAttributes = "Unwieldy",
                },
                new()
                {
                    Id =  3,
                    Name = "Handgun",
                    Range = 24,
                    Shots = 1,
                    Strength = "4",
                    ArmourPenetration = "2",
                    AttackAttributes = "Unwieldy",
                },
                new()
                {
                    Id = 4,
                    Name = "Longbow",
                    Range = 30,
                    Shots = 1,
                    Strength = "3",
                    ArmourPenetration = "0",
                    AttackAttributes = "Volley Fire",
                },
                new()
                {
                    Id = 5,
                    Name = "Pistol",
                    Range = 12,
                    Shots = 1,
                    Strength = "4",
                    ArmourPenetration = "2",
                    AttackAttributes = "Quick to Fire",
                },
                new()
                {
                    Id = 6,
                    Name = "Throwing Weapons",
                    Range = 8,
                    Shots = 2,
                    Strength = "as user",
                    ArmourPenetration = "as user",
                    AttackAttributes = "Accurate,Quick to Fire"
                },
                new()
                {
                    Id = 7,
                    Name = "Brace of Pistols",
                    Range = 12,
                    Shots = 2,
                    Strength = "4",
                    ArmourPenetration = "2",
                    AttackAttributes = "Quick to Fire.Counts as Paried Weapons in close combat"
                },
                new()
                {
                    Id = 8,
                    Name = "Long Rifle",
                    Range = 48,
                    Shots = 1,
                    Strength = "5",
                    ArmourPenetration = "3",
                    AttackAttributes = "Multiple Wounds (2, against Standard), Unwieldy",
                },
                new()
                {
                    Id = 9,
                    Name = "Repeater Gun",
                    Range = 48,
                    Shots = 3,
                    Strength = "4",
                    ArmourPenetration = "2",
                    AttackAttributes = "Unwieldy",
                },
                new()
                {
                    Id = 10,
                    Name = "Reapeater Pistol",
                    Range = 12,
                    Shots = 3,
                    Strength = "4",
                    ArmourPenetration = "2",
                    AttackAttributes = "Quick to Fire. If the model is also equipped with a Pistol , this weapon gains Shots 4"
                }
            });
    }
}