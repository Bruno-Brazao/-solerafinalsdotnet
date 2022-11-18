using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hpels_mx.Models;

public partial class HpelsmxDbContext : DbContext
{
    public HpelsmxDbContext()
    {
    }

    public HpelsmxDbContext(DbContextOptions<HpelsmxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hpelsmxDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasIndex(e => e.VehicleId, "IX_Claims_VehicleId");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Claims).HasForeignKey(d => d.VehicleId);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasIndex(e => e.OwnerId, "IX_Vehicles_OwnerId");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles).HasForeignKey(d => d.OwnerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
