﻿using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AyodhyaYatra.API.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AyodhyaYatraContext _context;
        public LoginRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangePassword(PasswordChangeRequest request)
        {
            var oldData = await _context.Users
                                            .Where(x => (x.Email == request.UserName || x.UserName == request.UserName) && x.Password == request.OldPassword)
                                            .FirstOrDefaultAsync();
            if (oldData == null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidCredentials, StaticValues.Error_InvalidOldPassword);
            }
            else if (oldData.IsDeleted)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_UserNotFound, StaticValues.Error_UserNotFound);
            }

            oldData.Password = request.NewPassword;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> Login(LoginRequest request)
        {
            try
            {
                var oldData = await _context.Users
                                           .Where(x => (x.UserName == request.UserName || x.Email == request.UserName) && x.Password == request.Password)
                                           .FirstOrDefaultAsync();
                if (oldData == null)
                {
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidCredentials, StaticValues.Error_InvalidCredentials);
                }
                else if (oldData.IsDeleted)
                {
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_UserNotFound, StaticValues.Error_UserNotFound);
                }
                else if (oldData.IsBlocked)
                {
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_UserAccountBlocked, StaticValues.Error_UserAccountBlocked);
                }
                else if (oldData.IsLocked)
                {
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_UserAccountLocked, StaticValues.Error_UserAccountLocked);
                }
                else if (!oldData.IsEmailVerified)
                {
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_UserAccountEmailNotVerified, StaticValues.Error_UserAccountEmailNotVerified);
                }
                return oldData;
            }
            catch (Exception ex)
            {

                throw;
            }

            return null;
        }

        public async Task<User> RegisterUser(User request)
        {
            request.IsEmailVerified = true;
            var entity = _context.Users.Add(request);
            entity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<bool> ResetPassword(string userName)
        {
            if (userName == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && (x.Email == userName || x.UserName == userName)).FirstOrDefaultAsync();
            if (oldData == null)
                return false;
            oldData.IsResetCodeInitiated = true;
            oldData.PasswordResetCode = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            oldData.PasswordResetCodeExpireOn = DateTime.Now.AddHours(48);
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> UpdateProfile(User request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyEmail(string token)
        {
            if (token == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && x.EmailVerificationCode == token && x.EmailVerificationCodeExpireOn >= DateTime.Now).FirstOrDefaultAsync();
            if (oldData == null)
                return false;
            oldData.EmailVerificationCodeExpireOn = DateTime.Now.AddMinutes(-1);
            oldData.EmailVerificationCode = string.Empty;
            oldData.IsEmailVerified = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> IsUserExist(string email)
        {
            return await _context.Users.Where(x => !x.IsDeleted && x.Email == email).CountAsync() > 0;
        }

        public async Task<bool> AssignRole(string email, string Role)
        {
            if (email == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && (x.Email == email || x.UserName == email)).FirstOrDefaultAsync();
            if (oldData == null)
                return false;
            oldData.Role = Role;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ResetEmailVerificationCode(string email)
        {
            if (email == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && (x.Email == email || x.UserName == email)).FirstOrDefaultAsync();
            if (oldData == null)
                return false;
            if (oldData.IsEmailVerified)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_EmailAlreadyVerified, StaticValues.Error_EmailAlreadyVerified);
            }

            oldData.EmailVerificationCode = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            oldData.PasswordResetCodeExpireOn = DateTime.Now.AddHours(48);
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(string email)
        {
            if (email == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && (x.Email == email || x.UserName == email)).FirstOrDefaultAsync();
            if (oldData == null)
                return false;

            oldData.IsDeleted = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> BlockUser(string email)
        {
            if (email == null)
                return false;
            var oldData = await _context.Users.Where(x => !x.IsDeleted && (x.Email == email || x.UserName == email)).FirstOrDefaultAsync();
            if (oldData == null)
                return false;

            oldData.IsBlocked = true;
            var entity = _context.Attach(oldData);
            entity.State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
