using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstProject.Models;

namespace FirstProject.Data
{
    public class FirstProjectContext : DbContext
    {
        //public FirstProjectContext (DbContextOptions<FirstProjectContext> options)
        //    : base(options)
        //{
        //}

        //public DbSet<FirstProject.Models.User> User { get; set; } = default!;


        //Code First Approch Domain Driven Design
        //whenever you want to scaffold model class (called Domain class)
        //into thedatabase you need DbSet of this class type and the name should be plural
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        //to inherit this DB context class
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder); here we write the connection string
            //Server . means localhost but you can coopy the name from SQLSERVER name
            optionsBuilder.UseSqlServer("Server=BATOOL\\SQLEXPRESS01;Database=CodeFirstDB;Integrated Security= true; TrustServerCertificate=true;");
        }

    }
}
