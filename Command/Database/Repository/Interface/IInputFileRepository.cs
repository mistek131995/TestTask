using TestTask.Command.Model.File;

namespace TestTask.Command.Database.Repository.Interface
{
    public interface IInputFileRepository
    {
        public Task<InputFile?> GetByInputFileIdAsync(int id);
        public Task<List<InputFile>> GetByInputFileIdsAsync(List<int> ids);

        public Task<int> SaveAsync(InputFile inputFile);
    }
}
