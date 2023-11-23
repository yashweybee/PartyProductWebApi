using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PartyProductWebApi.Models;

public partial class PartyProductWebApiContext : DbContext
{
    public PartyProductWebApiContext()
    {
    }

    public PartyProductWebApiContext(DbContextOptions<PartyProductWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignParty> AssignParties { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductRate> ProductRates { get; set; }

    public virtual DbSet<ProductRateLog> ProductRateLogs { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-I8CAHS7;Database=PartyProductWebApi;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=DESKTOP-I8CAHS7;Database=PartyProductWebApi;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignParty>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AssignParty");

            entity.HasOne(d => d.Party).WithMany()
                .HasForeignKey(d => d.PartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssignPar__Party__3A81B327");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AssignPar__Produ__3B75D760");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC078EA691E1");

            entity.ToTable("Invoice");

            entity.HasOne(d => d.Party).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__PartyId__412EB0B6");

            entity.HasOne(d => d.Product).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Product__4222D4EF");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Party__3214EC076D3DC541");

            entity.ToTable("Party");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0725BD5FA2");

            entity.ToTable("Product");
        });

        modelBuilder.Entity<ProductRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC0731EA6B61");

            entity.ToTable("ProductRate");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductRates)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRa__Produ__3E52440B");
        });

        modelBuilder.Entity<ProductRateLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC0757118224");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductRateLogs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductRa__Produ__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
