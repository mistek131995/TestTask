using TestTask.Command.Database.Repository.Interface;

namespace TestTask.Command.Database.Common;

public interface IRepositoryProvider
{
    IUserRepository UserRepository { get; }
    IInputFileRepository InputFileRepository { get; }
}
