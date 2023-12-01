using MassTransit;
using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace RabbitClient.Publishers;

public class GetCourseMessagePublisher : IMessagePublisher<GetCourseRequest, GetCourseResponse>
{
    private readonly IRequestClient<GetCourseRequest> _requestClient;

    public GetCourseMessagePublisher(IRequestClient<GetCourseRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public GetCourseResponse SendMessage(GetCourseRequest request)
    {
        Response<GetCourseResponse> result = _requestClient.GetResponse<GetCourseResponse>(request).Result;

        return result.Message;
    }
}
