using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class StudentRepository
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Students";


    public List<DbStudent> GetStudent() => _dbContext.Students.ToList();

    public DbStudent GetStudent(Guid studentId) =>
        _dbContext.Students
        .AsNoTracking()
        .Where(u => u.Id == studentId)
        .FirstOrDefault()!;

    public void CreateStudent(DbStudent student)
    {
        _dbContext.Add(student);

        _dbContext.SaveChanges();
    }

    public void EditStudent(DbStudent student)
    {
        _dbContext.Update(student);
        _dbContext.SaveChanges();
    }

    public void DeleteStudent(Guid studentId)
    {
        var student = _dbContext.Students.FirstOrDefault(u => u.Id == studentId);

        _dbContext.Remove(student);

        _dbContext.SaveChanges();
    }

    public bool IsData(Guid id) => _dbContext.Students.Any(u => u.Id == id);
}
