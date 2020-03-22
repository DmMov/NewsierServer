using System.Collections.Generic;
using System.Security.Claims;

namespace Newsier.Application.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(ICollection<Claim> claims);
    }
}
