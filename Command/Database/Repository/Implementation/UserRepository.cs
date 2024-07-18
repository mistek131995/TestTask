using TestTask.Command.Database.Repository.Interface;
using TestTask.Command.Model.User;

namespace TestTask.Command.Database.Repository.Implementation;

public class UserRepository(Context context) : IUserRepository
{
    public async Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> SaveAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
