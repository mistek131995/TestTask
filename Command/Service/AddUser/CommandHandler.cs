using MediatR;
using TestTask.Command.Database.Common;

namespace TestTask.Command.Service.AddUser;

public class CommandHandler(IRepositoryProvider repositoryProvider) : IRequestHandler<Command, int>
{
    public async Task<int> Handle(Command request, CancellationToken cancellationToken)
    {
        return 0;
    }
}
