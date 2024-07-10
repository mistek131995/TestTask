namespace TestTask.Command.Model.User;

public class ToDoItem
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime? DueDate { get; private set; }
    public string Priority { get; private set; }

    public ToDoItem(int id, string title, string description, bool isCompleted, DateTime? dueDate, string priority)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        DueDate = dueDate;
        Priority = priority;
    }

    public ToDoItem( string title, string description, bool isCompleted, DateTime? dueDate, string priority)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        DueDate = dueDate;
        Priority = priority;
    }
}
