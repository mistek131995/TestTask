using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database.Repository.Interface;
using TestTask.Command.Model.File;

namespace TestTask.Command.Database.Repository.Implementation
{
    public class InputFileRepository(Context context) : IInputFileRepository
    {
        public async Task<InputFile?> GetByInputFileIdAsync(int id) => 
            (await GetByInputFileIdsAsync([id])).FirstOrDefault();

        public async Task<List<InputFile>> GetByInputFileIdsAsync(List<int> ids)
        {
            var file = await context.InputFiles
                .Include(x => x.OutputFiles)
                .Where(x => ids.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync();

            return file
                .Select(x => new InputFile(
                    x.Id, 
                    x.LocalName, 
                    x.StartName, 
                    x.Directory, 
                    x.UserId)
                ).ToList();
        }

        public async Task<int> SaveAsync(InputFile inputFile)
        {
            var inputFileDB = new Entity.InputFile()
            {
                Id = inputFile.Id,
                StartName = inputFile.StartName,
                LocalName = inputFile.LocalName,
                Directory = inputFile.Directory,
                UserId = inputFile.UserId,
                OutputFiles = new List<Entity.OutputFile>()
            };

            context.InputFiles.Update(inputFileDB);
            await context.SaveChangesAsync();

            return inputFileDB.Id;
        }
    }
}
