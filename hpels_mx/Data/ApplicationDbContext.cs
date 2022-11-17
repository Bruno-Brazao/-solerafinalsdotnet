using hpels_mx.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hpels_mx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Owners> Owners { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Claims> Claims { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Vehicles>()
        //    .HasRequired<Owners>(s => s.CurrentGrade)
        //    .WithMany(g => g.Students)
        //    .HasForeignKey<int>(s => s.CurrentGradeId);

        //}
    }
}