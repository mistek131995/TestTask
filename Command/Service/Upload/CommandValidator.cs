using FluentValidation;

namespace TestTask.Command.Service.Upload
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.FormFiles).NotEmpty().WithMessage("Выберите файл для загрузки");
        }
    }
}
