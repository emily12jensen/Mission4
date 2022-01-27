using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieInputContext : DbContext
    {
        public MovieInputContext (DbContextOptions<MovieInputContext>options): base (options)
        {
         
        }

        public DbSet<MovieInput> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieInput>().HasData(

                new MovieInput
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
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
                    Category = "Romance/Drama",
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
                    Category = "Romance/Comedy",
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
