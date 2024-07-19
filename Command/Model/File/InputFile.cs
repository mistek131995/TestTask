namespace TestTask.Command.Model.File
{
    public class InputFile
    {
        public int Id { get; set; }
        public string LocalName { get; set; }
        public string StartName { get; set; }
        public string Directory {  get; set; }
        public int UserId { get; set; }

        public InputFile(int id, string localName, string startName, string directory, int userId)
        {
            Id = id;
            LocalName = localName;
            StartName = startName;
            Directory = directory;
            UserId = userId;
        }

        public InputFile(string localName, string startName, string directory, int userId)
        {
            LocalName = localName;
            StartName = startName;
            Directory = directory;
            UserId = userId;
        }
    }
}
