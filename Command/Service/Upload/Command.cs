using MediatR;

namespace TestTask.Command.Service.Upload
{
    public class Command : IRequest<int>
    {
        public IFormFileCollection FormFiles { get; set; }
    }
}
