using MassTransit;
using Models.Requests.Course;
using SS_WEB.Commands.Course.Interfaces;

namespace SS_Web.Consumers;

public class EditCourseConsumer : IConsumer<EditCourseRequest>
{
    private readonly IEditCourseCommand _command;

    public EditCourseConsumer(IEditCourseCommand command)
    {
        _command = command;
    }

    public Task Consume(ConsumeContext<EditCourseRequest> context)
    {
        var response = _command.Execute(context.Message);

        context.Respond(response);

        return Task.CompletedTask;
    }
}
