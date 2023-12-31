﻿using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider;

public class TeacherRepository : IBaseRepository<DbTeacher>
{
    private readonly UniversityDbContext _dbContext = new();

    public string TableName = "Teachers";

    public IQueryable<DbTeacher> GetAll() => _dbContext.Teachers;

    public DbTeacher Get(Guid teacherId)
    {
       return _dbContext.Teachers
        .AsNoTracking()
        .Where(u => u.Id == teacherId)
        .FirstOrDefault()!;
    }

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
            throw new Exception($"В таблице {TableName} нет Id = {teacher.Id}"); ;
        }

        teacherFromDB.Copy(teacher);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var teacher = _dbContext.Teachers.FirstOrDefault(u => u.Id == id);

        _dbContext.Teachers.Remove(teacher!);

        _dbContext.SaveChanges();
    }
}
