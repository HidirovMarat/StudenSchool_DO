using DbModels;
using Menu;
using Provider;
using WorkWithUser;

namespace Client4;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CourseRepository repository = new CourseRepository();

        DbCourse dbCourse = new DbCourse() { Id = Guid.NewGuid(),  Credit = 3, NameCourse = "NameCourse"};

        repository.CreateCourse(dbCourse);


        try
        {
            IInformation[] information = { new EF_CRUD() };

            Menu.Menu menu = new(information);

            menu.MakeMain();
        }
        catch (Exception ex)
        {
            DesignedMenu.WriteErrorMessages(ex.ToString());
        }
    }
}