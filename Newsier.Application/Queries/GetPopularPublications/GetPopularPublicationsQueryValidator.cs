using FluentValidation;

namespace Newsier.Application.Queries.GetPopularPublications
{
    public class GetPopularPublicationsQueryValidator : AbstractValidator<GetPopularPublicationsQuery>
    {
        public GetPopularPublicationsQueryValidator()
        {
            RuleFor(v => v.Count)
                .GreaterThan((ushort)0)
                .WithMessage("'Count' must be more than 0")
                .LessThanOrEqualTo((ushort)12)
                .WithMessage("'Count' must be less or equal to 12");
        }
    }
}
