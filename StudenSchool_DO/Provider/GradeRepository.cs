using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class GradeRepository
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Grades";


    public List<DbGrade> GetGrade() => _dbContext.Grades.ToList();

    public DbGrade GetGrade(Guid GradeId) =>
        _dbContext.Grades
        .AsNoTracking()
        .Where(u => u.Id == GradeId)
        .FirstOrDefault()!;

    public void CreateGrade(DbGrade grade)
    {
        _dbContext.Grades.Add(grade);

        _dbContext.SaveChanges();
    }

    public void EditGrade(DbGrade grade)
    {
        _dbContext.Grades.Update(grade);

        _dbContext.SaveChanges();
    }

    public void DeleteGrade(Guid id)
    {
        var grade = _dbContext.Grades.FirstOrDefault(u => u.Id == id);

        _dbContext.Grades.Remove(grade);

        _dbContext.SaveChanges();
    }

    public bool IsData(Guid id) => _dbContext.Grades.Any(u => u.Id == id);
}