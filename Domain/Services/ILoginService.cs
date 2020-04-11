using System.Threading.Tasks;
using EDzController.Domain.Services.Communication;

namespace EDzController.Domain.Services
{
    public interface ILoginService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
}