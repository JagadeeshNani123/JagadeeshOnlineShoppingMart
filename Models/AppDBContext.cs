using Microsoft.EntityFrameworkCore;

namespace MVCCore.Models
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=jagadeeshonlineshoppingmart;user=root;password=jagadeesh@123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            
        }
    }
}
