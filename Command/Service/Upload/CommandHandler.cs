using MediatR;
using TestTask.Command.Database.Common;
using TestTask.Common.Exception;

namespace TestTask.Command.Service.Upload
{
    internal class CommandHandler(IRepositoryProvider repositoryProvider, IConfiguration configuration) : IRequestHandler<Command, int>
    {
        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var uploadGuid = Guid.NewGuid().ToString();

            uploadPath = Path.Combine(uploadPath, uploadGuid);

            if (Directory.Exists(uploadPath))
                throw new HandledException("Директория уже существует");

            Directory.CreateDirectory(uploadPath);

            var file = request.FormFiles[0];
            var fileExtension = file.FileName.Split('.').LastOrDefault();
            var fileGuid = $"{Guid.NewGuid().ToString()}.{fileExtension}";
            var filePath = Path.Combine(uploadPath, fileGuid);

            var fileStream = file.OpenReadStream();
            var bytes = new byte[file.Length];
            fileStream.Read(bytes, 0, (int)file.Length);

            await File.WriteAllBytesAsync(filePath, bytes);

            return await repositoryProvider.InputFileRepository.SaveAsync(new Model.File.InputFile(fileGuid, file.FileName, uploadGuid, 0));
        }
    }
}
