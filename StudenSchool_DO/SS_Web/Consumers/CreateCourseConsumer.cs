using MassTransit;
using Models.Requests.Course;
using SS_WEB.Commands.Course.Interfaces;

namespace SS_Web.Consumers;

public class CreateCourseConsumer : IConsumer<CreateCourseRequest>
{
    private readonly ICreateCourseCommand _command;

    public CreateCourseConsumer(ICreateCourseCommand command)
    {
        _command = command;
    }

    public Task Consume(ConsumeContext<CreateCourseRequest> context)
    {
        var response = _command.Execute(context.Message);

        context.Respond(response);

        return Task.CompletedTask;
    }
}
