using Core.Entities.Concrete;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class CoffeiSoftContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B8EAQ1H;Database=CoffeiSoft;Trusted_Connection=true");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Email_Activation> Email_Activation { get; set; }
        public DbSet<Operation_Claim> Operation_Claim { get; set; }
        public DbSet<Order_Documentation> Order_Documentation { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment_Documentation> Payment_Documentation { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<User_Operation_Claim> User_Operation_Claim { get; set; }
    }
}
