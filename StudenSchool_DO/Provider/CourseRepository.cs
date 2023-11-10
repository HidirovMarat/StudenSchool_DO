using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class CourseRepository : IBaseRepository<DbCourse>
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Courses";

    public IQueryable<DbCourse> Get() => _dbContext.Courses;

    public DbCourse Get(Guid courseId) =>
        _dbContext.Courses
        .AsNoTracking()
        .Where(u => u.Id == courseId)
        .FirstOrDefault()!;

    public void Create(DbCourse course)
    {
        _dbContext.Courses .Add(course);

        _dbContext.SaveChanges();
    }

    public void Edit(DbCourse course)
    {
        DbCourse courseFromDB = _dbContext.Courses.Where(x => x.Id == course.Id).FirstOrDefault();

        if (courseFromDB == null)
        {
            return;
        }

        courseFromDB.Copy(course);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var course = _dbContext.Courses.FirstOrDefault(u => u.Id == id);

        _dbContext.Courses.Remove(course);

        _dbContext.SaveChanges();
    }

    //public bool IsData(Guid id) => _dbContext.Courses.Any(u => u.Id == id);
}
