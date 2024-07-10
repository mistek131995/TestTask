using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddUser = TestTask.Command.Service.AddUser;

namespace TestTask.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<JsonResult> AddUser([FromBody] AddUser.Command command)
    {
        var result = await mediator.Send(command);

        return Json(result);
    }
}
