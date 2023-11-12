using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class GradeRepository : IBaseRepository<DbGrade>
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Grades";


    public IQueryable<DbGrade> Get() => _dbContext.Grades;

    public DbGrade Get(Guid GradeId) =>
        _dbContext.Grades
        .AsNoTracking()
        .Where(u => u.Id == GradeId)
        .FirstOrDefault()!;

    public void Create(DbGrade grade)
    {
        _dbContext.Grades.Add(grade);

        _dbContext.SaveChanges();
    }

    public void Edit(DbGrade grade)
    {
        var gradeFromDB = _dbContext.Grades.Where(u => u.Id == grade.Id).FirstOrDefault();

        if (gradeFromDB == null)
        {
            return;
        }

        gradeFromDB.Copy(grade);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var grade = _dbContext.Grades.FirstOrDefault(u => u.Id == id);

        _dbContext.Grades.Remove(grade);

        _dbContext.SaveChanges();
    }

    //public bool IsData(Guid id) => _dbContext.Grades.Any(u => u.Id == id);
}