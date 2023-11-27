using MenuItem;
using Provider;
using Services;
using Services.Base;
using SS_Web.Actions;
using SS_Web.Actions.@base;
using SS_Web.Responses;
using SS_Web.Validators;
using SS_Web.Validators.@base;

namespace SS_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IInputStringService, WebInputStringService>();
            builder.Services.AddTransient<IOutputService, WebOutputService>();
            builder.Services.AddTransient<IInputNumberService, WebInputService>();
            builder.Services.AddTransient<IFibonacciNumbersActions, FibonacciNumbersActions>();
            builder.Services.AddTransient<IFileReaderActions, FileReaderActions>();
            builder.Services.AddTransient<FibonacciNumbers>();
            builder.Services.AddTransient<CreateFibonacciNumbersResponse>();
            builder.Services.AddTransient<FileReader>();
            builder.Services.AddTransient<IInputPathService, WebInputPathService>();
            builder.Services.AddTransient<CreateFileReaderResponse>();
            builder.Services.AddTransient<ICreateWebsiteSaveRequestValidator, CreateWebsiteSaveRequestValidator>();
            builder.Services.AddTransient<IWebsiteSaveActions, WebsiteSaveActions>();
            builder.Services.AddTransient<WebsiteSave>();
            builder.Services.AddTransient<CreateWebsiteSaveResponse>();


            builder.Services.AddTransient<ICourseActions, CourseActions>();
            builder.Services.AddTransient<IStudentActions, StudentActions>();
            builder.Services.AddTransient<ITeacherActions, TeacherActions>();
            builder.Services.AddTransient<IGradeActions, GradeActions>();

            builder.Services.AddTransient<CourseRepository>();
            builder.Services.AddTransient<StudentRepository>();
            builder.Services.AddTransient<TeacherRepository>();
            builder.Services.AddTransient<GradeRepository>();

            builder.Services.AddTransient<ICreateCourseRequestValidator, CreateCourseRequestValidator>();
            builder.Services.AddTransient<ICreateGradeRequestValidator, CreateGradeRequestValidator>();
            builder.Services.AddTransient<ICreateStudentRequestValidator, CreateStudentRequestValidator>();
            builder.Services.AddTransient<ICreateTeacherRequestValidator, CreateTeacherRequestValidator>();

            builder.Services.AddTransient<CreateCourseResponse>();
            builder.Services.AddTransient<CreateStudentResponse>();
            builder.Services.AddTransient<CreateTeacherResponse>();
            builder.Services.AddTransient<CreateGradeResponse>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}