using FluentValidation;
using Mediatr.CQRS.Contracts;

namespace VWB.Api.Commands
{
    public record AddFruitCommand : ICommand
    {
        public AddFruitCommand(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; }
        public string Color { get; }
    }

    public class AddFruitCommandValidator : AbstractValidator<AddFruitCommand>
    {
        public AddFruitCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Please specify a color");
        }
    }
}
