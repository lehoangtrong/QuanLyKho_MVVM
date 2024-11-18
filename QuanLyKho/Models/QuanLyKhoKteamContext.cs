﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuanLyKho.Models;

public partial class QuanLyKhoKteamContext : DbContext
{
    public QuanLyKhoKteamContext()
    {
    }

    public QuanLyKhoKteamContext(DbContextOptions<QuanLyKhoKteamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<InputInfo> InputInfos { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<OutputInfo> OutputInfos { get; set; }

    public virtual DbSet<Suplier> Supliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", true, true)
                  .Build();
        var strConn = config["ConnectionStrings:DefaultConnection"];

        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0707278F82");

            entity.ToTable("Customer");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Input>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Input__3214EC0707345B55");

            entity.ToTable("Input");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.DateInput).HasColumnType("datetime");
        });

        modelBuilder.Entity<InputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InputInf__3214EC078066C704");

            entity.ToTable("InputInfo");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.IdInput)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.IdObject)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.InputPrice).HasDefaultValue(0.0);
            entity.Property(e => e.OutputPrice).HasDefaultValue(0.0);

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdInp__37A5467C");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__Statu__36B12243");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Object__3214EC07308F47BE");

            entity.ToTable("Object");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Qrcode).HasColumnName("QRCode");

            entity.HasOne(d => d.IdSuplierNavigation).WithMany(p => p.Objects)
                .HasForeignKey(d => d.IdSuplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Object__IdSuplie__2B3F6F97");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.Objects)
                .HasForeignKey(d => d.IdUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Object__BarCode__2A4B4B5E");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Output__3214EC0741F3ABD0");

            entity.ToTable("Output");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.DateOutput).HasColumnType("datetime");
        });

        modelBuilder.Entity<OutputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutputIn__3214EC0731D7EDBC");

            entity.ToTable("OutputInfo");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.IdInputInfo)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.IdObject)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdCus__3E52440B");

            entity.HasOne(d => d.IdInputInfoNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdInputInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdInp__3D5E1FD2");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__Statu__3C69FB99");
        });

        modelBuilder.Entity<Suplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suplier__3214EC07444D427F");

            entity.ToTable("Suplier");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC07283E6D21");

            entity.ToTable("Unit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0731271398");

            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__IdRole__300424B4");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC070A21E697");

            entity.ToTable("UserRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}