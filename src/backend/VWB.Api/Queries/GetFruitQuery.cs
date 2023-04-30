using FluentValidation;
using Mediatr.CQRS.Contracts;

namespace VWB.Api.Queries
{
    public record GetFruitQuery : IQuery<GetFruitQuery.Response>
    {
        public string Name { get; }

        public GetFruitQuery(string name)
        {
            Name = name;
        }

        public class Response
        {
            public string Name { get; }
            public string Color { get; }

            public Response(string name, string color)
            {
                Name = name;
                Color = color;
            }
        }
    }

    public class GetFruitQueryValidator : AbstractValidator<GetFruitQuery>
    {
        public GetFruitQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Fruit name length >= 3");
        }
    }

}
