using Microsoft.EntityFrameworkCore;
using DB = TestTask.Command.Database.Entity;
using TestTask.Command.Database.Repository.Interface;
using TestTask.Command.Model.User;

namespace TestTask.Command.Database.Repository.Implementation;

public class UserRepository(Context context) : IUserRepository
{
    public async Task<User> GetByIdAsync(int id)
    {
        var user = await context.Users
            .Include(x => x.ToDoItems)
            .ThenInclude(x => x.Priority)
            .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Ошибка получения пользователя");

        return new User(user.Id, user.Name, user.ToDoItems.Select(x => new ToDoItem(x.Id, x.Title, x.Description, x.IsCompleted, x.DueDate, x.Priority.Level)).ToList());
    }

    public async Task<User> SaveAsync(User user)
    {
        var dbUser = new DB.User()
        {
            Id = user.Id,
            Name = user.Name,
            ToDoItems = user.ToDoItems.Select(x => new DB.ToDoItem()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                DueDate = x.DueDate,
                Priority = new DB.Priority()
                {
                    Level = x.Priority
                },
            }).ToList()
        };

        context.Update(dbUser);
        await context.SaveChangesAsync();

        return await GetByIdAsync(user.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        context.Remove(user);
        await context.SaveChangesAsync();
    }
}
