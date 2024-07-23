using MediatR;
using TestTask.Command.Database.Common;
using TestTask.Command.Helper;
using TestTask.Common.Exception;

namespace TestTask.Command.Service.Upload
{
    internal class CommandHandler(IRepositoryProvider repositoryProvider, IConfiguration configuration) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var directoryGuid = Guid.NewGuid().ToString();

            uploadPath = Path.Combine(uploadPath, directoryGuid);

            if (Directory.Exists(uploadPath))
                throw new HandledException("Директория уже существует");

            Directory.CreateDirectory(uploadPath);

            var file = request.FormFiles[0];
            var fileExtension = file.FileName.Split('.').LastOrDefault();
            var fileGuid = $"{Guid.NewGuid().ToString()}.{fileExtension}";
            var filePath = Path.Combine(uploadPath, fileGuid) ?? throw new HandledException("Не удалось создать путь для сохранения файла");

            using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            file.CopyTo(fileStream);

            await repositoryProvider.InputFileRepository.SaveAsync(new Model.File.InputFile(fileGuid, file.FileName, directoryGuid, 0));

            return directoryGuid;
        }
    }
}
