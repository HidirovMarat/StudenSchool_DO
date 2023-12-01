using MassTransit;
using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace RabbitClient.Publishers;

public class DeleteCourseMessagePublisher : IMessagePublisher<DeleteCourseRequest, DeleteCourseResponse>
{
    private readonly IRequestClient<DeleteCourseRequest> _requestClient;

    public DeleteCourseMessagePublisher(IRequestClient<DeleteCourseRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public DeleteCourseResponse SendMessage(DeleteCourseRequest request)
    {
        Response<DeleteCourseResponse> result = _requestClient.GetResponse<DeleteCourseResponse>(request).Result;

        return result.Message;
    }
}
