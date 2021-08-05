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
        public CoffeiSoftContext()
        {

        }

        public CoffeiSoftContext(DbContextOptions<CoffeiSoftContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B8EAQ1H;Database=CoffeiSoft;Trusted_Connection=true");
        }



        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Email_Activation> EmailActivation { get; set; }
        public DbSet<Operation_Claim> Operation_Claim { get; set; }
        public DbSet<Order_Documentation> Order_Documentation { get; set; }
        public DbSet<Order_Portion> Order_Portion { get; set; }
        public DbSet<Order_Type> Order_Type { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Payment_Name> Payment_Name { get; set; }
        public DbSet<Payment_Type> Payment_Type { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Table_Location> Table_Location { get; set; }
        public DbSet<Table_Name> Table_Name { get; set; }
        public DbSet<User_Operation_Claim> User_Operation_Claim { get; set; }
    }

}
