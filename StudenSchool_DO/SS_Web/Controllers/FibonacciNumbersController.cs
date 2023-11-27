using MenuItem;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Base;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class FibonacciNumbersController : Controller
{
    [HttpGet]
    public IActionResult Index([FromServices] IFibonacciNumbersActions fibonacciNumbersActions, int key)
    {
        return Ok(fibonacciNumbersActions.Get(key));
    }
}
