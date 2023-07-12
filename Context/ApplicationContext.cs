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
    public DbSet<MagicArmour> MagicArmours { get; set; } = null!;
    public DbSet<MagicWeaponUpgrade> MagicWeaponUpgrades { get; set; } = null!;
    public DbSet<MagicBanner> MagicBanners { get; set; } = null!;

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
        AddFraction(modelBuilder);
        AddCategories(modelBuilder);
        AddMagicItems(modelBuilder);
        AddCharacters(modelBuilder);
        AddCloseCombatWeapon(modelBuilder);
        AddRangeWeapon(modelBuilder);
        AddArmour(modelBuilder);
        AddCore(modelBuilder);
        AddSpecial(modelBuilder);
        AddImperialAuxiliaries(modelBuilder);
        AddImperilalArmoury(modelBuilder);
        AddSunnasFury(modelBuilder);
        AddEqupmentOptions(modelBuilder);
        AddOptionsToWeaponConnection(modelBuilder);
        WeaponToMagicWeaponManyToManyConnection(modelBuilder);
        AddArmourToMagicUpgrades(modelBuilder);
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
        Fraction eos = new() {
            Id = 1,
            Name = "Empire Of Sonnstahl"
        };
        Fraction noneFraction = new() {
            Id = 666,
            Name = "None Fraction"
        };
        modelBuilder.Entity<Fraction>().HasData(eos , noneFraction);
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
            },
            new()
            {
                Id = 666,
                Name = "None Categoriq",
                Limit = 500,
                FractionId = 1,
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
                PointCostPerAdditionalFigure  = 7,
                StartUnitSize = 20,
                MaxUnitSize = 50,
            },
            new()
            {
                Id = 8,
                Name = "Light Infantry",
                StartPointCoast = 130,
                CategorieId = 2,
                FractionId = 1,
                PointCostPerAdditionalFigure = 13,
                StartUnitSize = 10,
                MaxUnitSize = 20
            },
            new()
            {
                Id = 9,
                Name = "State Milita",
                StartPointCoast = 140,
                CategorieId = 2,
                FractionId = 1,
                PointCostPerAdditionalFigure = 6,
                StartUnitSize = 10,
                MaxUnitSize = 25,
            },
            new()
            {
                Id   = 10,
                Name = "Electoral Cavalry",
                StartPointCoast = 155,
                CategorieId = 2,
                FractionId = 1,
                PointCostPerAdditionalFigure = 23,
                StartUnitSize = 5,
                MaxUnitSize = 20,
            },
            new ()
            {
                Id = 11,
                Name = "Knightly Orders",
                StartPointCoast = 195,
                CategorieId = 2,
                FractionId = 1,
                PointCostPerAdditionalFigure = 31,
                StartUnitSize = 5,
                MaxUnitSize = 15,
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
                PointCostPerAdditionalFigure = 17,
                StartUnitSize = 15,
                MaxUnitSize = 40,
            },
            new ()
            {
                Id = 13,
                Name = "Knights of the Sun Griffon",
                CategorieId = 3,
                FractionId = 1,
                StartPointCoast = 275,
                PointCostPerAdditionalFigure = 59,
                StartUnitSize = 3,
                MaxUnitSize = 6
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
                PointCostPerAdditionalFigure = 11,
                StartUnitSize = 5,
                MaxUnitSize = 10,
            },
            new()
            {
                Id = 16,
                Name = "Reiters",
                CategorieId = 4,
                FractionId = 1,
                StartPointCoast = 155,
                PointCostPerAdditionalFigure = 21,
                StartUnitSize = 5,
                MaxUnitSize = 10
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
            PointCostPerAdditionalFigure = 15,
            StartUnitSize = 15,
            MaxUnitSize = 30
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
    private void AddMagicItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MagicWeaponUpgrade>()
            .HasData(new List<MagicWeaponUpgrade>(){
                new()
                {
                    Id = 1,
                    Name = "The Light of Sonnstahl",
                    PointCoast = 150,
                    Description = "Attacks made with weapon automatically and always have Armour Penetration 10",
                    FractioId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "Deaht Warrant",
                    PointCoast = 60,
                    Description = "Attacks made with this weapon gain Battle Focus. Ifa hit is scored with it against an enemy unit, friendly models with Parent Unit or Support Unit gain Battle Focus with attacks allocated towards the same enemy unit in the same phase in subsequent Initiative Steps.",
                    FractioId = 1,
                },
                new()
                {
                    Id = 3,
                    Name = "Hammer of Witches",
                    PointCoast = 45,
                    Description = "The bearer’s Attack Value is set to 5 while using this weapon, and attacks made with it gain Battle Focus (against Channel (X))",
                    FractioId = 1,
                },
            });
        modelBuilder.Entity<MagicArmour>()
            .HasData(new List<MagicArmour>() {
            new()
            {
                Id = 1,
                Name = "Imperial Seal",
                PointCoast = 100,
                Description = "The wearer gains +3 Armour and +1 Discipline. The wearer’s unit cannot voluntarily declare Flee as a Charge Reaction",
                FractioId = 1,
            },
            new()
            {
                Id = 2,
                Name = "BlackSteel",
                PointCoast = 45,
                Description = "The wearer gains +1 Armour and Fear. If taken by a model on foot, the wearer gains an additional +1 Armour",
                FractioId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Witchfire Guard",
                PointCoast = 35,
                Description = "The bearer gains Aegis (4+, against Magical Attacks) while using this Shield",
                FractioId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Shield of Volund",
                PointCoast = 15,
                Description = "While using this Shield, the bearer’s model gains Immune (Battle Focus, Lethal Strike",
                FractioId = 1,
            },
        });
        modelBuilder.Entity<MagicBanner>()
            .HasData(new List<MagicBanner>() {
                new ()
                {
                    Id = 1,
                    Name = "Household Standart",
                    PointCoast = 45,
                    Description = "If the General is part of the bearer’s unit, it gains Commanding Presence (+6)",
                    FractioId = 1,
                    CategorieId = 666,
                },
                new ()
                {
                    Id  = 2,
                    Name = "Banner of Unity",
                    Description = "Whenever the bearer’s unit is targeted by an Order, it may immediately give an Order to a single Support Unit within 8 of the bearer’s unit",
                    CategorieId = 1,
                    PointCoast = 45,
                    FractioId = 1,
                },
                new()
                {
                    Id = 3,
                    Name = "Marksman's Pennant",
                    Description = "The bearer's unit gains Steady Aim",
                    CategorieId = 666,
                    PointCoast = 10,
                    FractioId = 1,
                }
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
    private void AddEqupmentOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EqupmentOption>()
            .HasData(new List<EqupmentOption>() {
                #region AddCharacterEqupment
                //Marshal
                new ()
                {
                    Id = 1,
                    OptionCoast = 10,
                    UnitId = 1,
                    
                },
                new ()
                {
                    Id = 2,
                    OptionCoast = 5,
                    UnitId = 1,
                },
                new()
                {
                    Id = 3,
                    OptionCoast = 10,
                    UnitId = 1,
                },
                new()
                {
                    Id = 4,
                    OptionCoast = 5,
                    UnitId = 1,
                },
                new()
                {
                    Id = 5,
                    OptionCoast = 5,
                    UnitId = 1,
                },
                new()
                {
                    Id = 6,
                    OptionCoast = 5,
                    UnitId = 1,
                },
                new()
                {
                    Id = 7,
                    OptionCoast = 5,
                    UnitId = 1,
                },
                //Knight Commander
                new()
                {
                    Id = 8,
                    OptionCoast = 5,
                    UnitId = 2,
                },
                new ()
                {
                    Id = 9,
                    OptionCoast = 5,
                    UnitId = 2,
                },
                new()
                {
                    Id = 10,
                    OptionCoast = 5,
                    UnitId = 2,
                },
                new()
                {
                    Id = 11,
                    OptionCoast = 10,
                    UnitId = 2,
                },
                new()
                {
                    Id = 12,
                    OptionCoast = 30,
                    UnitId = 2
                },
                //Wizard
                new()
                {
                    Id = 13,
                    OptionCoast = 5,
                    UnitId = 3,
                },
                //Prelate
                new()
                {
                    Id = 14,
                    OptionCoast = 15,
                    UnitId = 4,
                },
                new()
                {
                    Id = 15,
                    OptionCoast = 0,
                    UnitId = 4,
                },
                new()
                {
                    Id = 16,
                    OptionCoast = 25,
                    UnitId = 4,
                },
                new()
                {
                    Id = 17,
                    OptionCoast = 5,
                    UnitId = 4,
                },
                new()
                {
                    Id = 18,
                    OptionCoast = 15,
                    UnitId = 4,
                }, 
                //Artificer
                new()
                {
                    Id = 19,
                    OptionCoast = 5,
                    UnitId = 5,
                },
                new()
                {
                    Id = 20,
                    OptionCoast = 5,
                    UnitId = 5,
                },
                new()
                {
                    Id = 21,
                    OptionCoast = 10,
                    UnitId = 5,
                },
                new()
                {
                    Id = 22,
                    OptionCoast = 10,
                    UnitId = 5
                },
                //Inquisitor
                new()
                {
                    Id = 23,
                    OptionCoast = 5,
                    UnitId = 6
                },
                new()
                {
                    Id = 24,
                    OptionCoast = 5,
                    UnitId = 6
                },
                new()
                {
                    Id= 25,
                    OptionCoast = 15,
                    UnitId = 6
                },
                new()
                {
                    Id = 26,
                    OptionCoast = 25,
                    UnitId = 6,
                },
                new()
                {
                    Id = 27,
                    OptionCoast = 5,
                    UnitId = 6,
                },
                new()
                {
                    Id = 28,
                    OptionCoast = 10,
                    UnitId = 6,
                },
                new()
                {
                    Id = 29,
                    OptionCoast = 10,
                    UnitId = 6
                },
                #endregion
                #region AddCoreEqupment
                new()
                {
                    Id = 30,
                    OptionCoast = 1,
                    UnitId = 7
                },
                new()
                {
                    Id = 31,
                    OptionCoast = 1,
                    UnitId = 7,
                },
                new()
                {
                    Id = 32,
                    OptionCoast = 0,
                    UnitId = 8,
                },
                new()
                {
                    Id = 33,
                    OptionCoast = 1,
                    UnitId = 8,
                },
                new()
                {
                    Id = 34,
                    OptionCoast = 4,
                    UnitId = 10,
                },
                new()
                {
                    Id = 35,
                    OptionCoast = 1,
                    UnitId = 10,
                },
                new()
                {
                    Id = 36,
                    OptionCoast = 1,
                    UnitId = 10,
                },
                //Knightly Orders
                new()
                {
                    Id = 37,
                    OptionCoast = 4,
                    UnitId = 11,
                },
                new()
                {
                    Id = 38,
                    OptionCoast = 1,
                    UnitId = 11,
                },
                new()
                {
                    Id = 39,
                    OptionCoast = 1,
                    UnitId = 11,
                },
                #endregion
                #region AddSpecialEqupment
                new()
                {
                    Id = 40,
                    OptionCoast = 0,
                    UnitId = 12
                },
                new()
                {
                    Id = 41,
                    OptionCoast = 2,
                    UnitId = 12
                },
                new()
                {
                    Id = 42,
                    OptionCoast = 0,
                    UnitId = 13
                },
                new()
                {
                    Id = 43,
                    OptionCoast = 10,
                    UnitId = 13
                },
                #endregion
                #region AddImperialAuxliliaries
                new()
                {
                    Id = 44,
                    OptionCoast = 3,
                    UnitId = 16
                },
                new()
                {
                    Id  = 45,
                    OptionCoast = 0,
                    UnitId = 16,
                },
                new()
                {
                    Id = 46,
                    OptionCoast = 5,
                    UnitId = 16
                },
                new()
                {
                    Id = 47,
                    OptionCoast = 6,
                    UnitId = 16
                }
                #endregion
            });
    }
    private void AddOptionsToWeaponConnection(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CloseCombatWeaponToOption>()
            .HasData(new List<CloseCombatWeaponToOption>() {
                new()
                { 
                    EqupmentOptionId = 4,
                    CloseCombatWeaponId = 1,
                },
                new()
                {
                    EqupmentOptionId = 5,
                    CloseCombatWeaponId = 2
                },
                new()
                {
                    EqupmentOptionId = 6,
                    CloseCombatWeaponId = 4,
                },
                new()
                {
                    EqupmentOptionId = 7,
                    CloseCombatWeaponId = 6,
                },
                new()
                {
                    EqupmentOptionId = 9,
                    CloseCombatWeaponId = 1,
                },
                new()
                {
                    EqupmentOptionId = 10,
                    CloseCombatWeaponId = 2
                },
                new()
                {
                    EqupmentOptionId = 11,
                    CloseCombatWeaponId = 4
                },
                new()
                {
                    EqupmentOptionId = 12,
                    CloseCombatWeaponId = 8,
                },
                new()
                {
                    EqupmentOptionId = 14,
                    CloseCombatWeaponId = 6,
                },
                new()
                {
                    EqupmentOptionId = 15,
                    CloseCombatWeaponId = 1,
                },
                new()
                {
                    EqupmentOptionId = 27,
                    CloseCombatWeaponId = 6
                },
                new()
                {
                    EqupmentOptionId = 28,
                    CloseCombatWeaponId = 1,
                },
                new()
                {
                    EqupmentOptionId = 29,
                    CloseCombatWeaponId = 2
                },
                new()
                {
                    EqupmentOptionId = 30,
                    CloseCombatWeaponId = 2,
                },
                new()
                {
                    EqupmentOptionId = 31,
                    CloseCombatWeaponId = 7
                },
                new()
                {
                    EqupmentOptionId = 35,
                    CloseCombatWeaponId = 1,
                },
                new()
                {
                    EqupmentOptionId = 36,
                    CloseCombatWeaponId = 4,
                },
                new()
                {
                    EqupmentOptionId = 38,
                    CloseCombatWeaponId = 4,
                },
                new()
                {
                    EqupmentOptionId = 39,
                    CloseCombatWeaponId = 8,
                },
               new()
                {
                    EqupmentOptionId = 41,
                    CloseCombatWeaponId = 1,
                },
               new()
               {
                   EqupmentOptionId = 42,
                   CloseCombatWeaponId = 2,
               },
               new()
               {
                   EqupmentOptionId = 43,
                   CloseCombatWeaponId = 4,
               },
               new()
               {
                   EqupmentOptionId = 44,
                   CloseCombatWeaponId = 5,
               }
            });
        modelBuilder.Entity<RangeWeaponToOption>()
            .HasData(new List<RangeWeaponToOption>() {
                new()
                {
                    EqupmentOptionId = 2,
                    RangeWeaponId = 10,
                },
                new()
                {
                  EqupmentOptionId   = 3,
                  RangeWeaponId = 5,
                },
                new()
                {
                    EqupmentOptionId = 19,
                    RangeWeaponId = 3
                },
                new()
                {
                    EqupmentOptionId = 20,
                    RangeWeaponId = 10
                },
                new()
                {
                    EqupmentOptionId = 21,
                    RangeWeaponId = 8
                },
                new()
                {
                    EqupmentOptionId = 22,
                    RangeWeaponId = 9
                },
                new()
                {
                    EqupmentOptionId = 24,
                    RangeWeaponId = 2
                },
                new()
                {
                    EqupmentOptionId = 25,
                    RangeWeaponId = 7
                },
                new()
                {
                    EqupmentOptionId = 26,
                    RangeWeaponId = 10
                },
                new()
                {
                    EqupmentOptionId = 32,
                    RangeWeaponId = 3,
                },
                new()
                {
                    EqupmentOptionId  = 33,
                    RangeWeaponId = 2
                },
                new()
                {
                    EqupmentOptionId = 45,
                    RangeWeaponId = 5,
                },
                new()
                {
                    EqupmentOptionId = 46,
                    RangeWeaponId = 7
                },
                new()
                {
                    EqupmentOptionId = 47,
                    RangeWeaponId = 10
                }
            });
        modelBuilder.Entity<ArmourToOption>()
            .HasData(new List<ArmourToOption>()
            {
               new()
                {
                    EqupmentOptionId = 1,
                    ArmourId = 4
                },
                new()
                {
                    EqupmentOptionId = 8,
                    ArmourId = 4,
                },
                new()
                {
                    EqupmentOptionId  = 13,
                    ArmourId = 1
                },
                new()
                {
                    EqupmentOptionId  = 14,
                    ArmourId = 4,
                },
                new()
                {
                    EqupmentOptionId = 15,
                    ArmourId = 2,
                },
                new()
                {
                    EqupmentOptionId = 16,
                    ArmourId = 3,
                },
                new()
                {
                    EqupmentOptionId = 23,
                    ArmourId = 4,
                },
                new()
                {
                    EqupmentOptionId = 34,
                    ArmourId = 4
                },
                new()
                {
                    EqupmentOptionId = 37,
                    ArmourId = 4,
                },
                new()
                {
                    EqupmentOptionId = 40,
                    ArmourId = 4,
                },
                new()
                {
                    EqupmentOptionId = 44,
                    ArmourId = 2,
                },
                new()
                {
                    EqupmentOptionId = 45,
                    ArmourId = 4,
                }
            });
    }
    private void WeaponToMagicWeaponManyToManyConnection(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CloseCombatWeaponToMagicUpgrade>()
            .HasData(new List<CloseCombatWeaponToMagicUpgrade>()
            {
                new()
                {
                    CloseCombatWeaponId = 3,
                    MagicWeaponUpgradeId = 1,
                },
                new()
                {
                    CloseCombatWeaponId = 3,
                    MagicWeaponUpgradeId = 2,
                },
                new()
                {
                    CloseCombatWeaponId = 3,
                    MagicWeaponUpgradeId = 3
                },
            });
    }
    private void AddArmourToMagicUpgrades(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArmourToMagicUpgrade>()
            .HasData(new List<ArmourToMagicUpgrade>()
            {
                new()
                {
                    ArmourId = 3,
                    MagicArmourId = 1
                },
                new()
                {
                    ArmourId = 3,
                    MagicArmourId = 2,
                },
                new()
                {
                    ArmourId = 4,
                    MagicArmourId = 3,
                },
                new()
                {
                    ArmourId = 4,
                    MagicArmourId = 3,
                }
            });
    }

    private void AddCommandgroupUpgradeOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommandGroupUpgradeOption>()
            .HasData(new List<CommandGroupUpgradeOption>()
            {
                new()
                {
                    Id = 1,
                    UpgradeName = "Champion",
                    UpgradeCoast = 10,
                },
                new()
                {
                    Id = 2,
                    UpgradeName = "Musician",
                    UpgradeCoast = 10
                },
                new()
                {
                    Id = 3,
                    UpgradeName = "Standart Bearer",
                    UpgradeCoast = 10,
                }
            });
    }
}