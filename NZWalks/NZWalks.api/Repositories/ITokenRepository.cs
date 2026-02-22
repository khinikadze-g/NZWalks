using Microsoft.AspNetCore.Identity;

namespace NZWalks.api.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List <string> roles);
    }
}
