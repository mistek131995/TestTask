using FluentValidation;

namespace TestTask.Command.Service.AddUser;

public class CommandValidator : AbstractValidator<Command>
{
    public CommandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Имя обязально к заполнению");
    }
}
