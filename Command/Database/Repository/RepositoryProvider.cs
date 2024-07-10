using TestTask.Command.Database.Common;
using TestTask.Command.Database.Repository.Implementation;
using TestTask.Command.Database.Repository.Interface;

namespace TestTask.Command.Database.Repository;

public class RepositoryProvider(Context context) : IRepositoryProvider
{
    private IUserRepository userRepository;

    public IUserRepository UserRepository => 
        userRepository ??= new UserRepository(context);
}
