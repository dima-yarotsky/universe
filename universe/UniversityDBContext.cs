using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using universe.Models;

namespace universe
{
    public partial class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        {
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audience> Audiences { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Responsible> Responsibles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audience>(entity =>
            {
                entity.ToTable("Audience");

                entity.Property(e => e.AudienceId)
                    .ValueGeneratedNever()
                    .HasColumnName("audience_ID");

                entity.Property(e => e.ABuildId).HasColumnName("a_build_ID");

                entity.Property(e => e.ADepartmentId).HasColumnName("a_department_ID");

                entity.Property(e => e.AHeating).HasColumnName("a_heating");

                entity.Property(e => e.AResponsibleId).HasColumnName("a_responsible_ID");

                entity.Property(e => e.ASquare).HasColumnName("a_square");

                entity.Property(e => e.ATarget)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("a_target");

                entity.Property(e => e.AWindows).HasColumnName("a_windows");

                entity.HasOne(d => d.ABuild)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.ABuildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audience_Build");

                entity.HasOne(d => d.ADepartment)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.ADepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audience_Department");

                entity.HasOne(d => d.AResponsible)
                    .WithMany(p => p.Audiences)
                    .HasForeignKey(d => d.AResponsibleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audience_Responsible");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.BuildId)
                    .HasName("build_pk");

                entity.ToTable("Building");

                entity.Property(e => e.BuildId)
                    .ValueGeneratedNever()
                    .HasColumnName("build_ID");

                entity.Property(e => e.BAdress)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("b_adress");

                entity.Property(e => e.BKadastr).HasColumnName("b_kadastr");

                entity.Property(e => e.BLand).HasColumnName("b_land");

                entity.Property(e => e.BMaterial)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("b_material");

                entity.Property(e => e.BName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("b_name");

                entity.Property(e => e.BPicture).HasColumnName("b_picture");

                entity.Property(e => e.BWear).HasColumnName("b_wear");

                entity.Property(e => e.BYear).HasColumnName("b_year");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_ID");

                entity.Property(e => e.DBoss)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("d_boss");

                entity.Property(e => e.DName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("d_name");

                entity.Property(e => e.DOfficeDean)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("d_officeDean");

                entity.Property(e => e.DPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("d_phone");
            });

           
           

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId)
                    .ValueGeneratedNever()
                    .HasColumnName("property_ID");

                entity.Property(e => e.BAudienceId).HasColumnName("b_audience_ID");

                entity.Property(e => e.BCost)
                    .HasColumnType("money")
                    .HasColumnName("b_cost")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BCostAfter)
                    .HasColumnType("money")
                    .HasColumnName("b_costAfter")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BCostYear).HasColumnName("b_costYear");

                entity.Property(e => e.BPeriod).HasColumnName("b_period");

                entity.Property(e => e.BStart)
                    .HasColumnType("date")
                    .HasColumnName("b_start");

                entity.Property(e => e.PName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("p_name");

                entity.HasOne(d => d.BAudience)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.BAudienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Audience");
            });

           

            modelBuilder.Entity<Responsible>(entity =>
            {
                entity.ToTable("Responsible");

                entity.Property(e => e.ResponsibleId)
                    .ValueGeneratedNever()
                    .HasColumnName("responsible_ID");

                entity.Property(e => e.RAdressResp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("r_adressResp");

                entity.Property(e => e.RExperiense).HasColumnName("r_experiense");

                entity.Property(e => e.RName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("r_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
