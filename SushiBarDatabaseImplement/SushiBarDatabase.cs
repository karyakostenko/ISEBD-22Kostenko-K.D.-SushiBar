﻿using Microsoft.EntityFrameworkCore;
using SushiBarDatabaseImplement.Models;

namespace SushiBarDatabaseImplement
{
    public class SushiBarDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-48E31M6;Initial Catalog=SushiBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Ingredient> Ingredients { set; get; }
        public virtual DbSet<Sushi> Sushis { set; get; }
        public virtual DbSet<SushiIngredient> SushiIngredients { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Cook> Cooks { set; get; }
        public virtual DbSet<MessageInfo> Messages { set; get; }
    }
}
