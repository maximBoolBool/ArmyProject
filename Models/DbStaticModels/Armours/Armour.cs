﻿using ArmyProjectSecond.Models.DbStaticModels.Option;

namespace ArmyProjectSecond.Models.Armours;

public class Armoure
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<EqupmentOption> Options { get; set; }
}