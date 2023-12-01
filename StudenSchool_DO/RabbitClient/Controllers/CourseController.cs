using Microsoft.AspNetCore.Mvc;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using RabbitClient.Publishers;

namespace RabbitClient.Controllers;

[Route("[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(
      [FromServices] IMessagePublisher<CreateCourseRequest, CreateCourseResponse> messagePublisher,
      [FromBody] CreateCourseRequest request)
    {
        var result = messagePublisher.SendMessage(request);

        if (result.Id is null)
        {
            return BadRequest("Failed to create user");
        }

        return Created("/courses", result.Id);
    }

    [HttpGet]
    public IActionResult Get(
      [FromServices] IMessagePublisher<GetCourseRequest, GetCourseResponse> messagePublisher,
      [FromBody] GetCourseRequest request)
    {
        var result = messagePublisher.SendMessage(request);

        if (result.CourseInfo is null)
        {
            return BadRequest("Failed to create user");
        }

        return Created("/courses", result.CourseInfo);
    }

    [HttpDelete]
    public IActionResult Delete(
      [FromServices] IMessagePublisher<DeleteCourseRequest, DeleteCourseResponse> messagePublisher,
      [FromBody] DeleteCourseRequest request)
    {
        var result = messagePublisher.SendMessage(request);

        if (result.Id is null)
        {
            return BadRequest("Failed to create user");
        }

        return Ok(result.Id);
    }

    [HttpPut]
    public IActionResult Edit(
      [FromServices] IMessagePublisher<EditCourseRequest, EditCourseResponse> messagePublisher,
      [FromBody] EditCourseRequest request)
    {
        var result = messagePublisher.SendMessage(request);

        if (result.CourseInfo is null)
        {
            return BadRequest("Failed to create user");
        }

        return Created("/courses", result.CourseInfo);
    }
}
