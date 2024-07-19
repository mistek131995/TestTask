using System.ComponentModel.DataAnnotations;

namespace TestTask.Command.Database.Entity
{
    public class InputFile
    {
        [Key]
        public int Id { get; set; }
        public string LocalName { get; set; }
        public string StartName { get; set; }
        public string Directory { get; set; }
        public int UserId { get; set; }

        public List<OutputFile> OutputFiles { get; set; }
    }
}
