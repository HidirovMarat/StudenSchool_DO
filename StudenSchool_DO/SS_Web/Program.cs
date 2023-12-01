using MenuItem;
using Provider;
using Services;
using Services.Base;
using Models.Responses.CourseResponses;
using Models.Responses.FibonacciNumbersResponses;
using Models.Responses.FileReaderResponses;
using Models.Responses.GradeResponses;
using Models.Responses.StudentResponses;
using Models.Responses.TeacherResponses;
using Models.Responses.WebsiteSaveResponses;
using Models.Validators.Course;
using Models.Validators.Course.Interfaces;
using Models.Validators.Grade;
using Models.Validators.Grade.Interfaces;
using Models.Validators.Student;
using Models.Validators.Student.Interfaces;
using Models.Validators.Teacher;
using Models.Validators.Teacher.Interfaces;
using Models.Validators.WebsiteSave;
using Models.Validators.WebsiteSave.Interfaces;
using Models.Requests.Course;
using SS_WEB.Commands.Course.Interfaces;
using SS_WEB.Commands.Course;
using MassTransit;

namespace Models
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
            builder.Services.AddTransient<IInputPathService, WebInputPathService>();

            builder.Services.AddTransient<FibonacciNumbers>();
            builder.Services.AddTransient<FileReader>();
            builder.Services.AddTransient<ICreateWebsiteSaveRequestValidator, CreateWebsiteSaveRequestValidator>();
            builder.Services.AddTransient<WebsiteSave>();

            builder.Services.AddTransient<CourseRepository>();
            builder.Services.AddTransient<StudentRepository>();
            builder.Services.AddTransient<TeacherRepository>();
            builder.Services.AddTransient<GradeRepository>();

            builder.Services.AddTransient<ICreateCourseRequestValidator, CreateCourseRequestValidator>();
            builder.Services.AddTransient<ICreateGradeRequestValidator, CreateGradeRequestValidator>();
            builder.Services.AddTransient<ICreateStudentRequestValidator, CreateStudentRequestValidator>();
            builder.Services.AddTransient<ICreateTeacherRequestValidator, CreateTeacherRequestValidator>();

            builder.Services.AddTransient<ICreateCourseRequestValidator, CreateCourseRequestValidator>();
            builder.Services.AddTransient<ICreateGradeRequestValidator, CreateGradeRequestValidator>();
            builder.Services.AddTransient<ICreateStudentRequestValidator, CreateStudentRequestValidator>();
            builder.Services.AddTransient<ICreateTeacherRequestValidator, CreateTeacherRequestValidator>();

            builder.Services.AddTransient<ICreateCourseRequestValidator, CreateCourseRequestValidator>();
            builder.Services.AddTransient<ICreateGradeRequestValidator, CreateGradeRequestValidator>();
            builder.Services.AddTransient<ICreateStudentRequestValidator, CreateStudentRequestValidator>();
            builder.Services.AddTransient<ICreateTeacherRequestValidator, CreateTeacherRequestValidator>();

            builder.Services.AddTransient<GetAllCourseResponse>();
            builder.Services.AddTransient<GetCourseResponse>();
            builder.Services.AddTransient<CreateCourseResponse>();
            builder.Services.AddTransient<DeleteCourseResponse>();
            builder.Services.AddTransient<EditCourseResponse>();

            builder.Services.AddTransient<GetCourseRequest>();
            builder.Services.AddTransient<CreateCourseRequest>();
            builder.Services.AddTransient<DeleteCourseRequest>();
            builder.Services.AddTransient<EditCourseRequest>();


            builder.Services.AddTransient<IGetCourseRequestValidator, GetCourseRequestValidator>();
            builder.Services.AddTransient<ICreateCourseRequestValidator, CreateCourseRequestValidator>();
            builder.Services.AddTransient<IDeleteCourseRequestValidator, DeleteCourseRequestValidator>();
            builder.Services.AddTransient<IEditCourseRequestValidator, EditCourseRequestValidator>();

            builder.Services.AddTransient<IGetAllCourseCommand, GetAllCourseCommand>();
            builder.Services.AddTransient<IGetCourseCommand, GetCourseCommand>();
            builder.Services.AddTransient<ICreateCourseCommand, CreateCourseCommand>();
            builder.Services.AddTransient<IDeleteCourseCommand, DeleteCourseCommand>();
            builder.Services.AddTransient<IEditCourseCommand, EditCourseCommand>();

            try
            {
                builder.Services.AddMassTransit(x =>
                {
                    x.AddConsumers(typeof(Program).Assembly);

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost");
                        cfg.ConfigureEndpoints(context);
                    });
                });
            }
            catch (Exception)
            {

                throw new Exception("Failed to connect to rabbitmq");
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}