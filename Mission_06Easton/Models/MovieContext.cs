using Microsoft.EntityFrameworkCore;
namespace Mission_06Easton.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        //replace Application with the model C# equivalent in this app, APPLICATIONS is the name of the table so that can change too
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>.HasData(
        //        new Movie
        //        );
        //}
    }
}
