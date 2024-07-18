using MediatR;
using Microsoft.AspNetCore.Mvc;
using UploadCommand = TestTask.Command.Service.Upload;

namespace TestTask.Controllers;
[ApiController]
[Route("[controller]/[Action]")]
public class UserController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<JsonResult> Upload()
    {
        var command = new UploadCommand.Command();
        command.FormFiles = Request.Form.Files;

        var result = await mediator.Send(command);

        return Json(result);
    }
}
