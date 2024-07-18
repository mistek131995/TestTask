using System.ComponentModel.DataAnnotations;

namespace TestTask.Command.Database.Entity
{
    public class OutputFile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int InputFileId { get; set; }

        public InputFile InputFile { get; set; }
    }
}
