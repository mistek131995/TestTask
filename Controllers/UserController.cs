using MediatR;
using Microsoft.AspNetCore.Mvc;

using UploadCommand = TestTask.Command.Service.Upload;

using GetProjectQuery = TestTask.Query.Service.GetProject;

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

    [HttpGet]
    public async Task<JsonResult> GetProject(Guid guid)
    {
        var result = await mediator.Send(new GetProjectQuery.Query()
        {
            Guid = guid
        });

        return Json(result);
    }
}
