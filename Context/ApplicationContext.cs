
using ArmyProjectSecondTry.Models.ManyToMany;
using ArmyProjectSecondTry.Models.Options;
using ArmyProjectSecondTry.Models.Units;
using ArmyProjectSecondTry.Models.Weapons;
using Microsoft.EntityFrameworkCore;

namespace ArmyProjectSecondTry.Context;

public class ApplicationContext : DbContext
{

    
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

    }
}
