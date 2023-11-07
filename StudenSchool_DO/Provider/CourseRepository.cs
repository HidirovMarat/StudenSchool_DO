using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class CourseRepository
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Courses";

    public List<DbCourse> GetCourse() => _dbContext.Courses.ToList();

    public DbCourse GetCourse(Guid courseId) =>
        _dbContext.Courses
        .AsNoTracking()
        .Where(u => u.Id == courseId)
        .FirstOrDefault()!;

    public void CreateCourse(DbCourse course)
    {
        _dbContext.Courses .Add(course);

        _dbContext.SaveChanges();
    }

    public void EditCourse(DbCourse course)
    {
        _dbContext.Courses.Update(course);

        _dbContext.SaveChanges();
    }

    public void DeleteCourse(Guid id)
    {
        var course = _dbContext.Courses.FirstOrDefault(u => u.Id == id);

        _dbContext.Courses.Remove(course);

        _dbContext.SaveChanges();
    }

    public bool IsData(Guid id) => _dbContext.Courses.Any(u => u.Id == id);
}
