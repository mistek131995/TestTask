namespace TestTask.Query.Service.GetProject
{
    public class ViewModel
    {
        public _InputFile InputFile { get; set; }

        public class _InputFile()
        {
            public int Id { get; set; }
            public string FileName { get; set; }
            public long Size { get; set; }

            internal string Directory { get; set; }
            internal string LocalName { get; set; }
        }
    }
}
