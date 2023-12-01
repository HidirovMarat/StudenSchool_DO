using MassTransit;
using Models.Requests.Course;
using SS_WEB.Commands.Course.Interfaces;

namespace SS_Web.Consumers;

public class GetCourseConsumer : IConsumer<GetCourseRequest>
{
    private readonly IGetCourseCommand _command;

    public GetCourseConsumer(IGetCourseCommand command)
    {
        _command = command;
    }

    public Task Consume(ConsumeContext<GetCourseRequest> context)
    {
        var response = _command.Execute(context.Message);

        context.Respond(response);

        return Task.CompletedTask;
    }
}
