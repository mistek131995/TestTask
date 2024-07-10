using MediatR;

namespace TestTask.Command.Service.AddUser;

public class Command : IRequest<int>
{
    public string Name { get; set; }
}
