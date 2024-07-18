using System.ComponentModel.DataAnnotations;

namespace TestTask.Command.Database.Entity
{
    public class InputFile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Directory { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
        public List<OutputFile> OutputFiles { get; set; }
    }
}
