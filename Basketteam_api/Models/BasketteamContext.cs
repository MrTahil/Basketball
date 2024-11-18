using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Basketteam_api.Models;

public partial class BasketteamContext : DbContext
{
    public BasketteamContext()
    {
    }

    public BasketteamContext(DbContextOptions<BasketteamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Matchdatum> Matchdata { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=basketteam;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Matchdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("matchdata");

            entity.HasIndex(e => e.PlayerId, "Random");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Fault).HasColumnType("int(11)");
            entity.Property(e => e.Goal).HasColumnType("int(11)");
            entity.Property(e => e.In).HasColumnType("datetime");
            entity.Property(e => e.Out).HasColumnType("datetime");
            entity.Property(e => e.PlayerId).HasMaxLength(36);
            entity.Property(e => e.Try).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.Player).WithMany(p => p.Matchdata)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Random");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("player");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Height).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(37);
            entity.Property(e => e.Weight).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
