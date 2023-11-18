using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Provider;

public class StudentRepository : IBaseRepository<DbStudent>
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Students";

    public IQueryable<DbStudent> GetAll() => _dbContext.Students;

    public DbStudent Get(Guid studentId)
    {
        return _dbContext.Students
        .AsNoTracking()
        .Where(u => u.Id == studentId)
        .FirstOrDefault()!;
    }
    public void Create(DbStudent student)
    {
        _dbContext.Add(student);

        _dbContext.SaveChanges();
    }

    public void Edit(DbStudent student)
    {
        var studentFromDB = _dbContext.Students.Where(u => u.Id == student.Id).FirstOrDefault();

        if (studentFromDB == null)
        {
            throw new Exception($"В таблице {TableName} нет Id = {student.Id}"); ;
        }

        studentFromDB.Copy(student);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid studentId)
    {
        var student = _dbContext.Students.FirstOrDefault(u => u.Id == studentId)!;

        _dbContext.Remove(student);

        _dbContext.SaveChanges();
    }
}
