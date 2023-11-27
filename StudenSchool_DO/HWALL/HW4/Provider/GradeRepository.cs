using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class GradeRepository
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Grades";

    public IQueryable<DbGrade> GetAll() => _dbContext.Grades;

    public DbGrade Get(Guid studentId, Guid courseId)
    {
        return _dbContext.Grades
        .AsNoTracking()
        .Where(u => u.StudentId == studentId && u.CourseId == courseId)
        .FirstOrDefault()!;
    }

    public void Create(DbGrade grade)
    {
        _dbContext.Grades.Add(grade);

        _dbContext.SaveChanges();
    }

    public void Edit(DbGrade grade)
    {
        var gradeFromDB = _dbContext
            .Grades
            .Where(u => u.StudentId == grade.StudentId && u.CourseId == u.CourseId)
            .FirstOrDefault()!;

        if (gradeFromDB == null)
        {
            throw new Exception($"В таблице {TableName} нет CouselId = {grade.CourseId} and StudentId = {grade.StudentId}");
        }

        gradeFromDB.Copy(grade);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid studentId, Guid courseId)
    {
        var grade = _dbContext.Grades.FirstOrDefault(u => u.CourseId == courseId && u.StudentId == studentId)!;

        _dbContext.Grades.Remove(grade);

        _dbContext.SaveChanges();
    }
}