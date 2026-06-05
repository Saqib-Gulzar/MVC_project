using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectWithDatabase1.Models;

public partial class DatabaseForProject1Context : DbContext
{
    public DatabaseForProject1Context()
    {
    }
 
    public DatabaseForProject1Context(DbContextOptions<DatabaseForProject1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Roll).HasName("PK__Students__DA1541246E107E4A");

            entity.Property(e => e.Roll).ValueGeneratedNever();
            entity.Property(e => e.StudentDob).HasColumnName("StudentDOB");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
