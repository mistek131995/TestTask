using TestTask.Command.Model.User;

namespace TestTask.Command.Database.Repository.Interface;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> SaveAsync(User user);
    Task DeleteAsync(int id);
}
