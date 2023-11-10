using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class TeacherRepository : IBaseRepository<DbTeacher>
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Teachers";

    public IQueryable<DbTeacher> Get() => _dbContext.Teachers;

    public DbTeacher Get(Guid teacherId) =>
        _dbContext.Teachers
        .AsNoTracking()
        .Where(u => u.Id == teacherId)
        .FirstOrDefault()!;

    public void Create(DbTeacher teacher)
    {
        _dbContext.Teachers.Add(teacher);

        _dbContext.SaveChanges();
    }

    public void Edit(DbTeacher teacher)
    {
        var teacherFromDB = _dbContext.Teachers.Where(u => u.Id == teacher.Id).FirstOrDefault();

        if (teacherFromDB == null)
        {
            return;
        }

        teacherFromDB.Copy(teacher);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var teacher = _dbContext.Teachers.FirstOrDefault(u  => u.Id == id);

        _dbContext.Teachers.Remove(teacher!);

        _dbContext.SaveChanges();
    }

    //public bool IsData(Guid id) => _dbContext.Teachers.Any(u => u.Id == id);
}
