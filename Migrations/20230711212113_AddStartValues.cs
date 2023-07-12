using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArmyProjectSecond.Migrations
{
    /// <inheritdoc />
    public partial class AddStartValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CloseCombatWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseCombatWeapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandGroupUpgradeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpgradeName = table.Column<string>(type: "text", nullable: false),
                    UpgradeCoast = table.Column<int>(type: "integer", nullable: false),
                    ParrentUpgradeOptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandGroupUpgradeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommandGroupUpgradeOptions_CommandGroupUpgradeOptions_Parre~",
                        column: x => x.ParrentUpgradeOptionId,
                        principalTable: "CommandGroupUpgradeOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    Shots = table.Column<int>(type: "integer", nullable: false),
                    Strength = table.Column<string>(type: "text", nullable: false),
                    ArmourPenetration = table.Column<string>(type: "text", nullable: false),
                    AttackAttributes = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Limit = table.Column<int>(type: "integer", nullable: true),
                    FractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Fractions_FractionId",
                        column: x => x.FractionId,
                        principalTable: "Fractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicArmours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PointCoast = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FractioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicArmours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicArmours_Fractions_FractioId",
                        column: x => x.FractioId,
                        principalTable: "Fractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MagicWeaponUpgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PointCoast = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FractioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicWeaponUpgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicWeaponUpgrades_Fractions_FractioId",
                        column: x => x.FractioId,
                        principalTable: "Fractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartPointCoast = table.Column<int>(type: "integer", nullable: false),
                    CategorieId = table.Column<int>(type: "integer", nullable: false),
                    FractionId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PointCostPerAdditionalFigure = table.Column<int>(type: "integer", nullable: true),
                    StartUnitSize = table.Column<int>(type: "integer", nullable: true),
                    MaxUnitSize = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseUnit_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseUnit_Fractions_FractionId",
                        column: x => x.FractionId,
                        principalTable: "Fractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategorieId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PointCoast = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FractioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicBanners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicBanners_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicBanners_Fractions_FractioId",
                        column: x => x.FractioId,
                        principalTable: "Fractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArmourToMagicUpgrades",
                columns: table => new
                {
                    ArmourId = table.Column<int>(type: "integer", nullable: false),
                    MagicArmourId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourToMagicUpgrades", x => new { x.ArmourId, x.MagicArmourId });
                    table.ForeignKey(
                        name: "FK_ArmourToMagicUpgrades_Armours_ArmourId",
                        column: x => x.ArmourId,
                        principalTable: "Armours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmourToMagicUpgrades_MagicArmours_MagicArmourId",
                        column: x => x.MagicArmourId,
                        principalTable: "MagicArmours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CloseCombatWeaponToMagicUpgrades",
                columns: table => new
                {
                    CloseCombatWeaponId = table.Column<int>(type: "integer", nullable: false),
                    MagicWeaponUpgradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseCombatWeaponToMagicUpgrades", x => new { x.CloseCombatWeaponId, x.MagicWeaponUpgradeId });
                    table.ForeignKey(
                        name: "FK_CloseCombatWeaponToMagicUpgrades_CloseCombatWeapons_CloseCo~",
                        column: x => x.CloseCombatWeaponId,
                        principalTable: "CloseCombatWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CloseCombatWeaponToMagicUpgrades_MagicWeaponUpgrades_MagicW~",
                        column: x => x.MagicWeaponUpgradeId,
                        principalTable: "MagicWeaponUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeaponToMagicUpgades",
                columns: table => new
                {
                    RangeWeaponId = table.Column<int>(type: "integer", nullable: false),
                    MagicWeaponUpgradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeaponToMagicUpgades", x => new { x.MagicWeaponUpgradeId, x.RangeWeaponId });
                    table.ForeignKey(
                        name: "FK_RangeWeaponToMagicUpgades_MagicWeaponUpgrades_MagicWeaponUp~",
                        column: x => x.MagicWeaponUpgradeId,
                        principalTable: "MagicWeaponUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RangeWeaponToMagicUpgades_RangeWeapons_RangeWeaponId",
                        column: x => x.RangeWeaponId,
                        principalTable: "RangeWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMagicPointCoastLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMagicPointCoastLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterMagicPointCoastLimit_BaseUnit_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "BaseUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandGroupOptionToUnits",
                columns: table => new
                {
                    CommandGroupUpgradeOptionsId = table.Column<int>(type: "integer", nullable: false),
                    UnitsId = table.Column<int>(type: "integer", nullable: false),
                    CommandGroupId = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandGroupOptionToUnits", x => new { x.CommandGroupUpgradeOptionsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_CommandGroupOptionToUnits_BaseUnit_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "BaseUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandGroupOptionToUnits_CommandGroupUpgradeOptions_Comman~",
                        column: x => x.CommandGroupUpgradeOptionsId,
                        principalTable: "CommandGroupUpgradeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaxModelCountPerArmy = table.Column<int>(type: "integer", nullable: false),
                    FractionId = table.Column<int>(type: "integer", nullable: true),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelLimit_BaseUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "BaseUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelLimit_Fractions_FractionId",
                        column: x => x.FractionId,
                        principalTable: "Fractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MountOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PointCoast = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    CategorieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountOptions_BaseUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "BaseUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountOptions_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionCoast = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponOptions_BaseUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "BaseUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmourToOptions",
                columns: table => new
                {
                    ArmourId = table.Column<int>(type: "integer", nullable: false),
                    EqupmentOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourToOptions", x => new { x.ArmourId, x.EqupmentOptionId });
                    table.ForeignKey(
                        name: "FK_ArmourToOptions_Armours_ArmourId",
                        column: x => x.ArmourId,
                        principalTable: "Armours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmourToOptions_WeaponOptions_EqupmentOptionId",
                        column: x => x.EqupmentOptionId,
                        principalTable: "WeaponOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CloseCombatWeaponToOptions",
                columns: table => new
                {
                    CloseCombatWeaponId = table.Column<int>(type: "integer", nullable: false),
                    EqupmentOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseCombatWeaponToOptions", x => new { x.CloseCombatWeaponId, x.EqupmentOptionId });
                    table.ForeignKey(
                        name: "FK_CloseCombatWeaponToOptions_CloseCombatWeapons_CloseCombatWe~",
                        column: x => x.CloseCombatWeaponId,
                        principalTable: "CloseCombatWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CloseCombatWeaponToOptions_WeaponOptions_EqupmentOptionId",
                        column: x => x.EqupmentOptionId,
                        principalTable: "WeaponOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RangeWeaponToOptions",
                columns: table => new
                {
                    RangeWeaponId = table.Column<int>(type: "integer", nullable: false),
                    EqupmentOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeWeaponToOptions", x => new { x.EqupmentOptionId, x.RangeWeaponId });
                    table.ForeignKey(
                        name: "FK_RangeWeaponToOptions_RangeWeapons_RangeWeaponId",
                        column: x => x.RangeWeaponId,
                        principalTable: "RangeWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RangeWeaponToOptions_WeaponOptions_EqupmentOptionId",
                        column: x => x.EqupmentOptionId,
                        principalTable: "WeaponOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Armours",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "+1 Armour", "Light Armour" },
                    { 2, "+2 Armour", "Heavy Armour" },
                    { 3, "+3 Armour", "Plate Armour" },
                    { 4, "+1 Armour. While using a Two-Handed weapon, a Shield is only used when being attacked by Ranged Attacks", "Shield" }
                });

            migrationBuilder.InsertData(
                table: "CloseCombatWeapons",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Two-Handed. Attacks made with a Great Weapon gain +2 Strength, +2 Armour Penetration, and strike at Initiative Step 0 (regardless of the wielder’s Agility)", "Great Weapon" },
                    { 2, "Two-Handed. Attacks made with a Halberd gain +1Strength and +1 Armour Penetration", "Halbred" },
                    { 3, "Gains Parry if model have Shield", "Hand Weapon" },
                    { 4, "Attacks made with a Lance and allocated towards models in the wielder’s Front Facing gain Devastating Charge (+2 Strength, +2 Armour Penetration). Infantry cannot use Lance", "Lance" },
                    { 5, "Attacks made with a Light Lance and allocated towards models in the wielder’s Front Facing gain Devastating Charge (+1 Strength, +1 Armour Penetration).Infantry cannot use Light Lances.", "Light Lance" },
                    { 6, "Two-Handed. The wielder gains +1 Attack Value and +1 Offensive Skill when using Paired Weapons.Attacks made with Paired Weapons ignore Parry (while PairedWeapons are often modelled as two Hand Weapons,they are considered a separate weapon category for rules purposes).", "Paried Weapons" },
                    { 7, "Attacks made with a Spear gain Fight in Extra Rank and +1 Armour Penetration. In addition, unless theattacking model’s unit is Charging or is Engaged in anyFlank or Rear Facing, attacks made with a Spear gain +2Agility and an additional +1 Armour Penetration in theFirst Round of Combat. Only Infantry can use Spears.", "Spear" },
                    { 8, "Attacks made with this weapon gain +2 Armour Penetration", "Cavalry Peak" }
                });

            migrationBuilder.InsertData(
                table: "Fractions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Empire Of Sonnstahl" },
                    { 666, "None Fraction" }
                });

            migrationBuilder.InsertData(
                table: "RangeWeapons",
                columns: new[] { "Id", "ArmourPenetration", "AttackAttributes", "Description", "Name", "Range", "Shots", "Strength" },
                values: new object[,]
                {
                    { 1, "0", "Volley Fire", null, "Bow", 24, 1, "3" },
                    { 2, "1", "Unwieldy", null, "Crossbow", 30, 1, "4" },
                    { 3, "2", "Unwieldy", null, "Handgun", 24, 1, "4" },
                    { 4, "0", "Volley Fire", null, "Longbow", 30, 1, "3" },
                    { 5, "2", "Quick to Fire", null, "Pistol", 12, 1, "4" },
                    { 6, "as user", "Accurate,Quick to Fire", null, "Throwing Weapons", 8, 2, "as user" },
                    { 7, "2", "Quick to Fire.Counts as Paried Weapons in close combat", null, "Brace of Pistols", 12, 2, "4" },
                    { 8, "3", "Multiple Wounds (2, against Standard), Unwieldy", null, "Long Rifle", 48, 1, "5" },
                    { 9, "2", "Unwieldy", null, "Repeater Gun", 48, 3, "4" },
                    { 10, "2", "Quick to Fire. If the model is also equipped with a Pistol , this weapon gains Shots 4", null, "Reapeater Pistol", 12, 3, "4" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "FractionId", "Limit", "Name" },
                values: new object[,]
                {
                    { 1, 1, 40, "Characters" },
                    { 2, 1, 25, "Core" },
                    { 3, 1, null, "Special" },
                    { 4, 1, 35, "Imperial Auxiliaries" },
                    { 5, 1, 20, "Imperial Armoury" },
                    { 6, 1, 30, "Sunna's Fury" },
                    { 666, 1, 500, "None Categoriq" }
                });

            migrationBuilder.InsertData(
                table: "MagicArmours",
                columns: new[] { "Id", "Description", "FractioId", "Name", "PointCoast" },
                values: new object[,]
                {
                    { 1, "The wearer gains +3 Armour and +1 Discipline. The wearer’s unit cannot voluntarily declare Flee as a Charge Reaction", 1, "Imperial Seal", 100 },
                    { 2, "The wearer gains +1 Armour and Fear. If taken by a model on foot, the wearer gains an additional +1 Armour", 1, "BlackSteel", 45 },
                    { 3, "The bearer gains Aegis (4+, against Magical Attacks) while using this Shield", 1, "Witchfire Guard", 35 },
                    { 4, "While using this Shield, the bearer’s model gains Immune (Battle Focus, Lethal Strike", 1, "Shield of Volund", 15 }
                });

            migrationBuilder.InsertData(
                table: "MagicWeaponUpgrades",
                columns: new[] { "Id", "Description", "FractioId", "Name", "PointCoast" },
                values: new object[,]
                {
                    { 1, "Attacks made with weapon automatically and always have Armour Penetration 10", 1, "The Light of Sonnstahl", 150 },
                    { 2, "Attacks made with this weapon gain Battle Focus. Ifa hit is scored with it against an enemy unit, friendly models with Parent Unit or Support Unit gain Battle Focus with attacks allocated towards the same enemy unit in the same phase in subsequent Initiative Steps.", 1, "Deaht Warrant", 60 },
                    { 3, "The bearer’s Attack Value is set to 5 while using this weapon, and attacks made with it gain Battle Focus (against Channel (X))", 1, "Hammer of Witches", 45 }
                });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "Name", "StartPointCoast" },
                values: new object[,]
                {
                    { 1, 1, "Character", 1, "Marshal", 140 },
                    { 2, 1, "Character", 1, "Knight Commander", 175 },
                    { 3, 1, "Character", 1, "Wizard", 115 },
                    { 4, 1, "Character", 1, "Prelate", 145 },
                    { 5, 1, "Character", 1, "Artificer", 120 },
                    { 6, 1, "Character", 1, "Inquisitor", 95 }
                });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "MaxUnitSize", "Name", "PointCostPerAdditionalFigure", "StartPointCoast", "StartUnitSize" },
                values: new object[,]
                {
                    { 7, 2, "MultiModelUnit", 1, 50, "Heavy Infantry", 7, 140, 20 },
                    { 8, 2, "MultiModelUnit", 1, 20, "Light Infantry", 13, 130, 10 },
                    { 9, 2, "MultiModelUnit", 1, 25, "State Milita", 6, 140, 10 },
                    { 10, 2, "MultiModelUnit", 1, 20, "Electoral Cavalry", 23, 155, 5 },
                    { 11, 2, "MultiModelUnit", 1, 15, "Knightly Orders", 31, 195, 5 },
                    { 12, 3, "MultiModelUnit", 1, 40, "Imperial Guard", 17, 170, 15 },
                    { 13, 3, "MultiModelUnit", 1, 6, "Knights of the Sun Griffon", 59, 275, 3 }
                });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "Name", "StartPointCoast" },
                values: new object[] { 14, 3, "SingleModelUnit", 1, "Arcane Engine", 255 });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "MaxUnitSize", "Name", "PointCostPerAdditionalFigure", "StartPointCoast", "StartUnitSize" },
                values: new object[,]
                {
                    { 15, 4, "MultiModelUnit", 1, 10, "Imperial Rangers", 11, 90, 5 },
                    { 16, 4, "MultiModelUnit", 1, 10, "Reiters", 21, 155, 5 }
                });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "Name", "StartPointCoast" },
                values: new object[] { 17, 5, "SingleModelUnit", 1, "Artillerry", 150 });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "MaxUnitSize", "Name", "PointCostPerAdditionalFigure", "StartPointCoast", "StartUnitSize" },
                values: new object[] { 18, 6, "MultiModelUnit", 1, 30, "Flagellants", 15, 185, 15 });

            migrationBuilder.InsertData(
                table: "BaseUnit",
                columns: new[] { "Id", "CategorieId", "Discriminator", "FractionId", "Name", "StartPointCoast" },
                values: new object[] { 19, 6, "SingleModelUnit", 1, "Steam Tank", 450 });

            migrationBuilder.InsertData(
                table: "MagicBanners",
                columns: new[] { "Id", "CategorieId", "Description", "FractioId", "Name", "PointCoast" },
                values: new object[,]
                {
                    { 1, 666, "If the General is part of the bearer’s unit, it gains Commanding Presence (+6)", 1, "Household Standart", 45 },
                    { 2, 1, "Whenever the bearer’s unit is targeted by an Order, it may immediately give an Order to a single Support Unit within 8 of the bearer’s unit", 1, "Banner of Unity", 45 },
                    { 3, 666, "The bearer's unit gains Steady Aim", 1, "Marksman's Pennant", 10 }
                });

            migrationBuilder.InsertData(
                table: "WeaponOptions",
                columns: new[] { "Id", "OptionCoast", "UnitId" },
                values: new object[,]
                {
                    { 1, 10, 1 },
                    { 2, 5, 1 },
                    { 3, 10, 1 },
                    { 4, 5, 1 },
                    { 5, 5, 1 },
                    { 6, 5, 1 },
                    { 7, 5, 1 },
                    { 8, 5, 2 },
                    { 9, 5, 2 },
                    { 10, 5, 2 },
                    { 11, 10, 2 },
                    { 12, 30, 2 },
                    { 13, 5, 3 },
                    { 14, 15, 4 },
                    { 15, 0, 4 },
                    { 16, 25, 4 },
                    { 17, 5, 4 },
                    { 18, 15, 4 },
                    { 19, 5, 5 },
                    { 20, 5, 5 },
                    { 21, 10, 5 },
                    { 22, 10, 5 },
                    { 23, 5, 6 },
                    { 24, 5, 6 },
                    { 25, 15, 6 },
                    { 26, 25, 6 },
                    { 27, 5, 6 },
                    { 28, 10, 6 },
                    { 29, 10, 6 },
                    { 30, 1, 7 },
                    { 31, 1, 7 },
                    { 32, 0, 8 },
                    { 33, 1, 8 },
                    { 34, 4, 10 },
                    { 35, 1, 10 },
                    { 36, 1, 10 },
                    { 37, 4, 11 },
                    { 38, 1, 11 },
                    { 39, 1, 11 },
                    { 40, 0, 12 },
                    { 41, 2, 12 },
                    { 42, 0, 13 },
                    { 43, 10, 13 },
                    { 44, 3, 16 },
                    { 45, 0, 16 },
                    { 46, 5, 16 },
                    { 47, 6, 16 }
                });

            migrationBuilder.InsertData(
                table: "ArmourToOptions",
                columns: new[] { "ArmourId", "EqupmentOptionId" },
                values: new object[,]
                {
                    { 1, 13 },
                    { 2, 15 },
                    { 2, 44 },
                    { 3, 16 },
                    { 4, 1 },
                    { 4, 8 },
                    { 4, 14 },
                    { 4, 23 },
                    { 4, 34 },
                    { 4, 37 },
                    { 4, 40 },
                    { 4, 45 }
                });

            migrationBuilder.InsertData(
                table: "CloseCombatWeaponToOptions",
                columns: new[] { "CloseCombatWeaponId", "EqupmentOptionId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 9 },
                    { 1, 15 },
                    { 1, 28 },
                    { 1, 35 },
                    { 1, 41 },
                    { 2, 5 },
                    { 2, 10 },
                    { 2, 29 },
                    { 2, 30 },
                    { 2, 42 },
                    { 4, 6 },
                    { 4, 11 },
                    { 4, 36 },
                    { 4, 38 },
                    { 4, 43 },
                    { 5, 44 },
                    { 6, 7 },
                    { 6, 14 },
                    { 6, 27 },
                    { 7, 31 },
                    { 8, 12 },
                    { 8, 39 }
                });

            migrationBuilder.InsertData(
                table: "RangeWeaponToOptions",
                columns: new[] { "EqupmentOptionId", "RangeWeaponId" },
                values: new object[,]
                {
                    { 2, 10 },
                    { 3, 5 },
                    { 19, 3 },
                    { 20, 10 },
                    { 21, 8 },
                    { 22, 9 },
                    { 24, 2 },
                    { 25, 7 },
                    { 26, 10 },
                    { 32, 3 },
                    { 33, 2 },
                    { 45, 5 },
                    { 46, 7 },
                    { 47, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmourToMagicUpgrades_MagicArmourId",
                table: "ArmourToMagicUpgrades",
                column: "MagicArmourId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmourToOptions_EqupmentOptionId",
                table: "ArmourToOptions",
                column: "EqupmentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUnit_CategorieId",
                table: "BaseUnit",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUnit_FractionId",
                table: "BaseUnit",
                column: "FractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FractionId",
                table: "Categories",
                column: "FractionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMagicPointCoastLimit_CharacterId",
                table: "CharacterMagicPointCoastLimit",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseCombatWeaponToMagicUpgrades_MagicWeaponUpgradeId",
                table: "CloseCombatWeaponToMagicUpgrades",
                column: "MagicWeaponUpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CloseCombatWeaponToOptions_EqupmentOptionId",
                table: "CloseCombatWeaponToOptions",
                column: "EqupmentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandGroupOptionToUnits_UnitsId",
                table: "CommandGroupOptionToUnits",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandGroupUpgradeOptions_ParrentUpgradeOptionId",
                table: "CommandGroupUpgradeOptions",
                column: "ParrentUpgradeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicArmours_FractioId",
                table: "MagicArmours",
                column: "FractioId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicBanners_CategorieId",
                table: "MagicBanners",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicBanners_FractioId",
                table: "MagicBanners",
                column: "FractioId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicWeaponUpgrades_FractioId",
                table: "MagicWeaponUpgrades",
                column: "FractioId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelLimit_FractionId",
                table: "ModelLimit",
                column: "FractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelLimit_UnitId",
                table: "ModelLimit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MountOptions_CategorieId",
                table: "MountOptions",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_MountOptions_UnitId",
                table: "MountOptions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RangeWeaponToMagicUpgades_RangeWeaponId",
                table: "RangeWeaponToMagicUpgades",
                column: "RangeWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_RangeWeaponToOptions_RangeWeaponId",
                table: "RangeWeaponToOptions",
                column: "RangeWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponOptions_UnitId",
                table: "WeaponOptions",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmourToMagicUpgrades");

            migrationBuilder.DropTable(
                name: "ArmourToOptions");

            migrationBuilder.DropTable(
                name: "CharacterMagicPointCoastLimit");

            migrationBuilder.DropTable(
                name: "CloseCombatWeaponToMagicUpgrades");

            migrationBuilder.DropTable(
                name: "CloseCombatWeaponToOptions");

            migrationBuilder.DropTable(
                name: "CommandGroupOptionToUnits");

            migrationBuilder.DropTable(
                name: "MagicBanners");

            migrationBuilder.DropTable(
                name: "ModelLimit");

            migrationBuilder.DropTable(
                name: "MountOptions");

            migrationBuilder.DropTable(
                name: "RangeWeaponToMagicUpgades");

            migrationBuilder.DropTable(
                name: "RangeWeaponToOptions");

            migrationBuilder.DropTable(
                name: "MagicArmours");

            migrationBuilder.DropTable(
                name: "Armours");

            migrationBuilder.DropTable(
                name: "CloseCombatWeapons");

            migrationBuilder.DropTable(
                name: "CommandGroupUpgradeOptions");

            migrationBuilder.DropTable(
                name: "MagicWeaponUpgrades");

            migrationBuilder.DropTable(
                name: "RangeWeapons");

            migrationBuilder.DropTable(
                name: "WeaponOptions");

            migrationBuilder.DropTable(
                name: "BaseUnit");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fractions");
        }
    }
}
