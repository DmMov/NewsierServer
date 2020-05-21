using FluentValidation;

namespace Newsier.Application.Queries.GetPopularPublications
{
    public class GetPopularPublicationsQueryValidator : AbstractValidator<GetPopularPublicationsQuery>
    {
        public GetPopularPublicationsQueryValidator()
        {
            RuleFor(v => v.Count)
                .GreaterThan((short)0)
                .WithMessage(x => $"'Count' must be more than 0, but was {x.Count}")
                .LessThanOrEqualTo((short)12)
                .WithMessage(x => $"'Count' must be less or equal to 12, but was {x.Count}");
        }
    }
}
