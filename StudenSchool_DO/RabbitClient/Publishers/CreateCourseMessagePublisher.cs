using MassTransit;
using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace RabbitClient.Publishers;

public class CreateCourseMessagePublisher : IMessagePublisher<CreateCourseRequest, CreateCourseResponse>
{
    private readonly IRequestClient<CreateCourseRequest> _requestClient;

    public CreateCourseMessagePublisher(IRequestClient<CreateCourseRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public CreateCourseResponse SendMessage(CreateCourseRequest request)
    {
        Response<CreateCourseResponse> result = _requestClient.GetResponse<CreateCourseResponse>(request).Result;

        return result.Message;
    }
}
