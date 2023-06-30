using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Models;

public partial class HealthCareContext : DbContext
{
    public HealthCareContext()
    {
    }

    public HealthCareContext(DbContextOptions<HealthCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;Database=HealthCare;integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488F6841A61");

            entity.ToTable("Admin");

            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2BE7D9AFA");

            entity.ToTable("Appointment");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Appointment_DoctorId");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Appointment_userId");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EBF35D098AB");

            entity.ToTable("Doctor");

            entity.Property(e => e.Gender).HasMaxLength(11);
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RequestedDate)
                .HasColumnType("datetime")
                .HasColumnName("requestedDate");
            entity.Property(e => e.RespondedDate)
                .HasColumnType("datetime")
                .HasColumnName("respondedDate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6137E6EC4");

            entity.ToTable("Feedback");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Feedback1).HasColumnName("Feedback");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Feedback_Appointment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF64F9C4BB");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
