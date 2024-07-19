using TestTask.Command.Database.Common;
using TestTask.Command.Database.Repository.Implementation;
using TestTask.Command.Database.Repository.Interface;

namespace TestTask.Command.Database.Repository;

public class RepositoryProvider(Context context) : IRepositoryProvider
{
    private IUserRepository userRepository;
    private IInputFileRepository inputFileRepository;

    public IUserRepository UserRepository => 
        userRepository ??= new UserRepository(context);

    public IInputFileRepository InputFileRepository => 
        inputFileRepository ?? new InputFileRepository(context);
}
