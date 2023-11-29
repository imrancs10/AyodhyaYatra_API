using KaashiYatra.API.DTO.Request;
using KaashiYatra.API.DTO.Response;
using KaashiYatra.API.Models;

namespace KaashiYatra.API.Services.IServices
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<UserResponse> RegisterUser(UserRequest request);
        Task<bool> ChangePassword(PasswordChangeRequest request);
        Task<string> ResetPassword(string userName);
        Task<string> VerifyEmail(string token);
        Task<bool> UpdateProfile(UserRequest request);
        Task<bool> AssignRole(string email, string Role);
        Task<bool> ResetEmailVerificationCode(string email);
        Task<bool> DeleteUser(string email);
        Task<bool> BlockUser(string email);
    }
}
