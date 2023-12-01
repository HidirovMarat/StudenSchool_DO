using MassTransit;
using MassTransit.RabbitMqTransport;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using RabbitClient.Publishers;

namespace RabbitClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<
              IMessagePublisher<CreateCourseRequest, CreateCourseResponse>,
              CreateCourseMessagePublisher>();

            builder.Services.AddScoped<
              IMessagePublisher<GetCourseRequest, GetCourseResponse>,
              GetCourseMessagePublisher>();

            builder.Services.AddScoped<
              IMessagePublisher<EditCourseRequest, EditCourseResponse>,
              EditCourseMessagePublisher>();

            builder.Services.AddScoped<
              IMessagePublisher<DeleteCourseRequest, DeleteCourseResponse>,
              DeleteCourseMessagePublisher>();

            try
            {
                builder.Services.AddMassTransit(x =>
                {
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