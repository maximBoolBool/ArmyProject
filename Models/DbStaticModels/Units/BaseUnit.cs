﻿using System.ComponentModel.DataAnnotations.Schema;
using ArmyProjectSecondTry.Models.Options;
using ArmyProjectSecondTry.Models.UnitsCategories;

namespace ArmyProjectSecondTry.Models.Units;

public abstract class BaseUnit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PointCost { get; set; }
    
    [ForeignKey("Categorie")]
    public int UnitCategorieId { get; set; }
    
    public UnitCategorie Categorie { get; set; }
    public List<WeaponOption> UnitWeaponOptios { get; set; }
    public List<SpecialRuleOption> UnitSpecialRuleOptions { get; set; }
}