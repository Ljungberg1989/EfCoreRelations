﻿using Microsoft.EntityFrameworkCore;

namespace EfCoreRelations;
public class BaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=./Database/EfCoreRelations.sqlite");
    }
}