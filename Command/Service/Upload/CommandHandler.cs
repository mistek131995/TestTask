using FluentValidation;
using MediatR;

namespace TestTask.Command.Service.Upload
{
    internal class CommandHandler : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var uploadGuid = Guid.NewGuid().ToString();

            uploadPath = Path.Combine(uploadPath, uploadGuid);

            if (Directory.Exists(uploadPath))
                throw new ValidationException("Директория уже существует");

            Directory.CreateDirectory(uploadPath);

            var file = request.FormFiles[0];
            var fileExtension = file.FileName.Split('.').LastOrDefault();
            var fileGuid = $"{Guid.NewGuid().ToString()}.{fileExtension}";
            var filePath = Path.Combine(uploadPath, fileGuid);
            
            var fileStream = file.OpenReadStream();
            var bytes = new byte[file.Length];
            fileStream.Read(bytes, 0, (int)file.Length);

            await File.WriteAllBytesAsync(filePath, bytes);

            return fileGuid;
        }
    }
}
