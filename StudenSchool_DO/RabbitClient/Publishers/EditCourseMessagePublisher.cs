using MassTransit;
using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace RabbitClient.Publishers;

public class EditCourseMessagePublisher : IMessagePublisher<EditCourseRequest, EditCourseResponse>
{
    private readonly IRequestClient<EditCourseRequest> _requestClient;

    public EditCourseMessagePublisher(IRequestClient<EditCourseRequest> requestClient)
    {
        _requestClient = requestClient;
    }

    public EditCourseResponse SendMessage(EditCourseRequest request)
    {
        Response<EditCourseResponse> result = _requestClient.GetResponse<EditCourseResponse>(request).Result;

        return result.Message;
    }
}
