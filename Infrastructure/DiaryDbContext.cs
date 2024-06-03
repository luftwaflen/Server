using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public class DiaryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<DiaryNote> DiaryNotes { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeRelation> RecipeRelations { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<FamilyRole> FamilyRoles { get; set; }

    public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RecipeRelation>()
            .HasKey(pdr => new { pdr.PatientId, pdr.DoctorId, pdr.RecipeId });

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Patient)
            .WithMany(p => p.RecipeRelations)
            .HasForeignKey(pdr => pdr.PatientId);

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Doctor)
            .WithMany(d => d.RecipeRelations)
            .HasForeignKey(pdr => pdr.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Recipe)
            .WithOne(r => r.RecipeRelation);
        //.HasForeignKey(pdr => pdr.RecipeId);
    }
}