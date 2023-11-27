using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class UniversityDbContext : DbContext
{
    public DbSet<DbStudent> Students { get; set; } = null!;

    public DbSet<DbCourse> Courses { get; set; } = null!;

    public DbSet<DbGrade> Grades { get; set; } = null!;

    public DbSet<DbTeacher> Teachers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Universite;Trusted_Connection=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbGrade>().HasKey(u => new { u.StudentId, u.CourseId });
    }
}