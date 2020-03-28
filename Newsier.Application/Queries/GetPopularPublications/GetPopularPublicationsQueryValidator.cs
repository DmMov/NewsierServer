using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPopularPublications
{
    public class GetPopularPublicationsQueryValidator : AbstractValidator<GetPopularPublicationsQuery>
    {
        public GetPopularPublicationsQueryValidator()
        {
            RuleFor(v => v.Count)
                .LessThanOrEqualTo<GetPopularPublicationsQuery, ushort>(12)
                .WithMessage("'Count' must be less or equal to '12'");
        }
    }
}
