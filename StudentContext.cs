using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister
{
    public class StudentContext : DbContext
    {

        private string _connectionString = "";

        public DbSet<Student>? Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(

               new Student("Samuel", "Andersson", "Örebro"),
                new Student("Fredrik", "Milton", "Örebro"),
                new Student("Sven", "Tumba", "Stockholm"),
                new Student("Robert", "Johansson", "Karlstad")
            );
        }


    }
}

// add-migration message

// update-database
