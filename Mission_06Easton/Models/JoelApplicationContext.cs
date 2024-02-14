using Microsoft.EntityFrameworkCore;
namespace Mission_06Easton.Models
{
    public class JoelApplicationContext: DbContext
    {
        public JoelApplicationContext(DbContextOptions<JoelApplicationContext>options): base (options) 
        {
        }

        //replace Application with the model C# equivalent in this app, APPLICATIONS is the name of the table so that can change too
        public DbSet<Movie> Movies { get; set; }
    }
}
