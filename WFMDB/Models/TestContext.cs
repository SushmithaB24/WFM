using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WFMDB.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Employee1> Employees1 { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Skillmap> Skillmaps { get; set; } = null!;
        public virtual DbSet<Softlock> Softlocks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.Experience)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("experience");

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lockstatus");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.WfmManager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wfm_manager");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.EmployeeManagerNavigations)
                    .HasForeignKey(d => d.Manager)
                    .HasConstraintName("mgrkey");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("fkkpfl");

                entity.HasOne(d => d.WfmManagerNavigation)
                    .WithMany(p => p.EmployeeWfmManagerNavigations)
                    .HasForeignKey(d => d.WfmManager)
                    .HasConstraintName("wmgrkey");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employees");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Experience)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("experience");

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lockstatus");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.WfmManager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wfm_manager");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skills");

                entity.Property(e => e.Skillid)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("skillid");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Skillmap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("skillmap");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Skillid)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("skillid");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("skillemp_skill");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.Skillid)
                    .HasConstraintName("skillempid");
            });

            modelBuilder.Entity<Softlock>(entity =>
            {
                entity.HasKey(e => e.Lockid)
                    .HasName("PK__softlock__B2B463D84F9EA9DE");

                entity.ToTable("softlock");

                entity.Property(e => e.Lockid).HasColumnName("lockid");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("date")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Managerstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("managerstatus")
                    .HasDefaultValueSql("('awaiting_approval')");

                entity.Property(e => e.Mgrlastupdate)
                    .HasColumnType("date")
                    .HasColumnName("mgrlastupdate");

                entity.Property(e => e.Mgrstatuscomment)
                    .HasColumnType("text")
                    .HasColumnName("mgrstatuscomment");

                entity.Property(e => e.Reqdate)
                    .HasColumnType("date")
                    .HasColumnName("reqdate");

                entity.Property(e => e.Requestmessage)
                    .HasColumnType("text")
                    .HasColumnName("requestmessage");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Wfmremark)
                    .HasColumnType("text")
                    .HasColumnName("wfmremark");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Softlocks)
                    .HasForeignKey(d => d.Manager)
                    .HasConstraintName("slmgrkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__users__F3DBC573F4F3E222");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
