﻿// Vanliga versionen med navigation properties.

using Microsoft.EntityFrameworkCore;

namespace EfCoreRelations.OneToManyUsingFluent1;

public class Parent
{
    // Key
    public int MyCustomPK { get; set; }

    // Nav
    public ICollection<Child> Children { get; set; } // Navigation property som EF tolkar för att skapa relationen.
}

public class Child
{
    // Key
    public int MyCustomPK { get; set; }
    public int MyCustomParentFK { get; set; }

    // Nav
    public Parent Parent { get; set; } // Navigation property som EF tolkar för att skapa relationen.
}



public class OneToManyUsingFluent1Context : BaseContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Child> Children { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>()
            .HasKey(c => c.MyCustomPK);
        modelBuilder.Entity<Child>()
            .HasOne(c => c.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(c => c.MyCustomParentFK);

        modelBuilder.Entity<Parent>()
            .HasKey(p => p.MyCustomPK);
    }
}
