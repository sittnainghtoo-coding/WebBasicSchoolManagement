using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAttendance> TblAttendances { get; set; }

    public virtual DbSet<TblExam> TblExams { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<TblTimeTable> TblTimeTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=SchoolManagementSystem_db;User ID=sa;Password=12345678;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAttendance>(entity =>
        {
            entity.ToTable("Tbl_Attendance");

            entity.Property(e => e.Reason).HasMaxLength(50);
            entity.Property(e => e.StdId)
                .HasMaxLength(8)
                .HasColumnName("StdID");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblExam>(entity =>
        {
            entity.ToTable("Tbl_Exam");

            entity.Property(e => e.ExamType).HasMaxLength(30);
            entity.Property(e => e.Subject).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("Tbl_Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StdId)
                .HasMaxLength(50)
                .HasColumnName("StdID");
            entity.Property(e => e.StdName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.ToTable("Tbl_Subject");

            entity.Property(e => e.SubName).HasMaxLength(20);
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.HasKey(e => e.TecId);

            entity.ToTable("Tbl_Teacher");

            entity.Property(e => e.TecId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("TecID");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TecName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTimeTable>(entity =>
        {
            entity.ToTable("Tbl_TimeTable");

            entity.Property(e => e.Day).HasMaxLength(10);
            entity.Property(e => e.Period1).HasMaxLength(50);
            entity.Property(e => e.Period2).HasMaxLength(50);
            entity.Property(e => e.Period3).HasMaxLength(50);
            entity.Property(e => e.Period4).HasMaxLength(50);
            entity.Property(e => e.Period5).HasMaxLength(50);
            entity.Property(e => e.Period6).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
