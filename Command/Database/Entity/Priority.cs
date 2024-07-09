using System.ComponentModel.DataAnnotations;

namespace TestTask.Command.Database.Entity;

public class Priority
{
    [Key]
    public int Id { get; set; }
    public string Level { get; set; }
}
