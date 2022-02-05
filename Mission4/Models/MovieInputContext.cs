using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieInputContext : DbContext
    {
        public MovieInputContext(DbContextOptions<MovieInputContext> options) : base(options)
        {

        }

        public DbSet<MovieInput> responses { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Funny" },
                new Category { CategoryID = 2, CategoryName = "Action" },
                new Category {CategoryID = 3, CategoryName = "Romance"},
                new Category {CategoryID = 4, CategoryName = "Scary"}
                );

            mb.Entity<MovieInput>().HasData(

                new MovieInput
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title ="Hary Potter and the Sorcerers Stone",
                    Year = 2001,
                    Director = "Chris Columbus",
                    Rating =  "PG",
                    Edited = false,
                    Notes = "Awesome movie!",
                },
                new MovieInput
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Little Women",
                    Year = 2019,
                    Director = "Greta Gerwig",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Sav",
                    Notes = "Loved watching it! ",
                },
                new MovieInput
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "You Again",
                    Year = 2010,
                    Director = "Andy Fickman",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Lexi",
                    Notes = "Love Betty White! ",
                }
                ) ;
        }
    }
}
