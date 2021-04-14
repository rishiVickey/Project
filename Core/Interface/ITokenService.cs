using Core.Entity.identity;

namespace Core.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}