using MassTransit;
using Models.Requests.Course;
using SS_WEB.Commands.Course.Interfaces;

namespace SS_Web.Consumers;

public class DeleteCourseConsumer : IConsumer<DeleteCourseRequest>
{
    private readonly IDeleteCourseCommand _command;

    public DeleteCourseConsumer(IDeleteCourseCommand command)
    {
        _command = command;
    }

    public Task Consume(ConsumeContext<DeleteCourseRequest> context)
    {
        var response = _command.Execute(context.Message);

        context.Respond(response);

        return Task.CompletedTask;
    }
}
