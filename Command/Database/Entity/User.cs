using System.ComponentModel.DataAnnotations;

namespace TestTask.Command.Database.Entity;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
