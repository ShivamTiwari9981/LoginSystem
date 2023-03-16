using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginSystemAPI.Models
{
    public partial class LoginDbContext : DbContext
    {
        public LoginDbContext()
        {
        }

        public LoginDbContext(DbContextOptions<LoginDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCity> TblCities { get; set; } = null!;
        public virtual DbSet<TblClaim> TblClaims { get; set; } = null!;
        public virtual DbSet<TblCountry> TblCountries { get; set; } = null!;
        public virtual DbSet<TblGender> TblGenders { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblState> TblStates { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HOIDD44;Database=login_sys_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityCd)
                    .HasName("PK__tbl_city__031420605E1D8FF7");

                entity.ToTable("tbl_city");

                entity.Property(e => e.CityCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city_cd");

                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city_name");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state_cd");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK__tbl_clai__F9CC0896EB431BF8");

                entity.ToTable("tbl_claim");

                entity.Property(e => e.ClaimId).HasColumnName("claim_id");

                entity.Property(e => e.ClaimDisc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("claim_disc");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryCd)
                    .HasName("PK__tbl_coun__7E9504D90A6A2C81");

                entity.ToTable("tbl_country");

                entity.Property(e => e.CountryCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_cd");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_name");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblGender>(entity =>
            {
                entity.HasKey(e => e.GenderCd)
                    .HasName("PK__tbl_gend__9DF1BFC055AC3D2D");

                entity.ToTable("tbl_gender");

                entity.Property(e => e.GenderCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender_cd");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.GenderName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gender_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tbl_role__760965CC6632414B");

                entity.ToTable("tbl_role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.RoleDisc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role_disc");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateCd)
                    .HasName("PK__tbl_stat__81DDA61B744D39C8");

                entity.ToTable("tbl_state");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state_cd");

                entity.Property(e => e.CountryCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_cd");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__tbl_stud__2A33069A284C6779");

                entity.ToTable("tbl_student");

                entity.HasIndex(e => e.StudentEmail, "UQ__tbl_stud__820A8F3ECEC5CFB7")
                    .IsUnique();

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.CityCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city_cd");

                entity.Property(e => e.CountryCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country_cd");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.GenderCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender_cd");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state_cd");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("student_email");

                entity.Property(e => e.StudentFirstNam)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("student_first_nam");

                entity.Property(e => e.StudentLastNam)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("student_last_nam");

                entity.Property(e => e.StudentMobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("student_mobile");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .HasName("PK__tbl_user__60621ABCC9050417");

                entity.ToTable("tbl_user");

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UsrEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usr_email");

                entity.Property(e => e.UsrMobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("usr_mobile");

                entity.Property(e => e.UsrNam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_nam");

                entity.Property(e => e.UsrPwd)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("usr_pwd");

                entity.Property(e => e.UsrType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("usr_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
