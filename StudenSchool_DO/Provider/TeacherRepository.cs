using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class TeacherRepository
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Teachers";

    public List<DbTeacher> GetTeacher() => _dbContext.Teachers.ToList();

    public DbTeacher GetTeacher(Guid teacherId) =>
        _dbContext.Teachers
        .AsNoTracking()
        .Where(u => u.Id == teacherId)
        .FirstOrDefault()!;

    public void CreateTeacher(DbTeacher teacher)
    {
        _dbContext.Teachers.Add(teacher);

        _dbContext.SaveChanges();
    }

    public void EditTeacher(DbTeacher teacher)
    {
        _dbContext.Teachers.Update(teacher);

        _dbContext.SaveChanges();
    }

    public void DeleteTeacher(Guid id)
    {
        var teacher = _dbContext.Teachers.FirstOrDefault(u  => u.Id == id);

        _dbContext.Teachers.Remove(teacher!);

        _dbContext.SaveChanges();
    }

    public bool IsData(Guid id) => _dbContext.Teachers.Any(u => u.Id == id);
}
