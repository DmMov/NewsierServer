using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Newsier.Application.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(ICollection<Claim> claims);
    }
}
