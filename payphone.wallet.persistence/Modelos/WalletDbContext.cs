using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace payphone.wallet.persistence.Modelos;

public partial class WalletDbContext : DbContext
{
    
    public WalletDbContext(DbContextOptions<WalletDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserW> UserWs { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletMovement> WalletMovements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserW>(entity =>
        {
            entity.HasKey(e => e.Cod);

            entity.ToTable("UserW");

            entity.Property(e => e.Cod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cod");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreateAt).HasColumnName("createAt");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.CalendarAt).HasColumnName("calendarAt");
            entity.Property(e => e.CreateAt).HasColumnName("createAt");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("documentId");
            entity.Property(e => e.Locks)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("locks");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.UpdateAt).HasColumnName("updateAt");
            entity.Property(e => e.UserCreate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userCreate");
            entity.Property(e => e.UserUpdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userUpdate");

            entity.HasOne(d => d.UserCreateNavigation).WithMany(p => p.WalletUserCreateNavigations)
                .HasForeignKey(d => d.UserCreate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserW_Wallet");

            entity.HasOne(d => d.UserUpdateNavigation).WithMany(p => p.WalletUserUpdateNavigations)
                .HasForeignKey(d => d.UserUpdate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWu_Wallet");
        });

        modelBuilder.Entity<WalletMovement>(entity =>
        {
            entity.ToTable("WalletMovement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Available)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("available");
            entity.Property(e => e.CalendarAt).HasColumnName("calendarAt");
            entity.Property(e => e.CreateAt).HasColumnName("createAt");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.UserCreate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userCreate");
            entity.Property(e => e.WalletId).HasColumnName("walletId");

            entity.HasOne(d => d.UserCreateNavigation).WithMany(p => p.WalletMovements)
                .HasForeignKey(d => d.UserCreate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserW_WalletMovement");

            entity.HasOne(d => d.Wallet).WithMany(p => p.WalletMovements)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_WalletMovement");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
