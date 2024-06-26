﻿using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository
{
    public interface ILoginRepository
    {
        Task<User> Login(LoginRequest request);
        Task<User> RegisterUser(User request);
        Task<bool> ChangePassword(PasswordChangeRequest request);
        Task<bool> ResetPassword(string userName);
        Task<bool> VerifyEmail(string token);
        Task<bool> UpdateProfile(User request);
        Task<bool> IsUserExist(string email);
        Task<bool> AssignRole(string email,string Role);
        Task<bool> ResetEmailVerificationCode(string email);
        Task<bool> DeleteUser(string email);
        Task<bool> BlockUser(string email);
    }
}
