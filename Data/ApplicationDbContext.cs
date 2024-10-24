using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp2024.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Appetizer" },
				new Category { Id = 2, Name = "Entree" },
				new Category { Id = 3, Name = "Dessert" }
			);
		}
}
