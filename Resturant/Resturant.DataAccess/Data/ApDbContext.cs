using Microsoft.EntityFrameworkCore;
using Resturant_Pro.Models;

namespace Resturant_Pro.Data
{
    public class ApDbContext :DbContext
    {
        public ApDbContext (DbContextOptions<ApDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Displayorder = 1 },
                new Category { Id = 2, Name = "Scifi", Displayorder = 2 },
                new Category { Id = 3, Name = "History", Displayorder = 3 }
                );
        }
    }
}
