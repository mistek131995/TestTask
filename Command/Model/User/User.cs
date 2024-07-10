namespace TestTask.Command.Model.User;

public class User
{
    public int Id { get; }
    public string Name { get; private set; }
    private List<ToDoItem> _toDoItems;

    public IReadOnlyCollection<ToDoItem> ToDoItems => _toDoItems;

    public User(int id, string name, List<ToDoItem> toDoItems)
    {
        Id = id;
        Name = name;
        _toDoItems = toDoItems;
    }

    public User(string name)
    {
        Name = name;
        _toDoItems = new List<ToDoItem>();
    }

    public void AddToDoItem(ToDoItem toDoItem)
    {
        _toDoItems.Add(toDoItem);
    }
}
