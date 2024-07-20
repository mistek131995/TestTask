using MediatR;

namespace TestTask.Command.Service.Upload
{
    public class Command : IRequest<string>
    {
        public IFormFileCollection FormFiles { get; set; }
    }
}
