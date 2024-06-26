﻿using AutoMapper;
using AyodhyaYatra.API.Common;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Dto.Request;
using AyodhyaYatra.API.DTO.Request;
using AyodhyaYatra.API.DTO.Response;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Extension;
using AyodhyaYatra.API.Models;
using AyodhyaYatra.API.Repository;

namespace AyodhyaYatra.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;/**/
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IMapper mapper,IMailService mailService,IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task<bool> AssignRole(string email, string role)
        {
            return await _loginRepository.AssignRole(email, role);
        }

        public async Task<bool> BlockUser(string email)
        {
            return await _loginRepository.BlockUser(email);
        }

        public async Task<bool> ChangePassword(PasswordChangeRequest request)
        {
            return await _loginRepository.ChangePassword(request);
        }

        public async Task<bool> DeleteUser(string email)
        {
            return await _loginRepository.DeleteUser(email);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_NoDataSupplied, StaticValues.Error_NoDataSupplied);
            }

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidDataSupplied, StaticValues.Error_InvalidDataSupplied);
            }
            request.Password = request.Password.DecodeBase64();
            request.Password = PasswordHasher.GenerateHash(request.Password);

            LoginResponse response = new()
            {
                UserResponse = _mapper.Map<UserResponse>(await _loginRepository.Login(request))
            };

            if (response.UserResponse.Id == 0)
            {
                throw new UnauthorizedException();
            }

            response.AccessToken =Utility.Utility .GenerateAccessToken(response.UserResponse.Role);
            return response;
        }

        public async Task<UserResponse> RegisterUser(UserRequest request)
        {
           
            if (await _loginRepository.IsUserExist(request.Email))
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_EmailAlreadyRegistered);

            User user = _mapper.Map<User>(request);
            user.IsEmailVerified = _configuration.GetValue<int>("EnableEmailVerification",0)==0;
            user.Password = PasswordHasher.GenerateHash(request.Password.DecodeBase64());
            user.EmailVerificationCode = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            user.EmailVerificationCodeExpireOn = DateTime.Now.AddHours(48);
            var res= _mapper.Map<UserResponse>(await _loginRepository.RegisterUser(user));
            if(res.Id>0)
            {
                var emailBody = await _mailService.GetMailTemplete(Constants.EmailTemplateEnum.EmailVerification);

                MailRequest mailRequest = new()
                {
                    ToEmail = request.Email,
                    Body = emailBody,
                    Subject = "Emai verification | Ayodhya Yatri"
                };
               // _mailService.SendEmailAsync(mailRequest);
            }
            return res;
        }

        public async Task<bool> ResetEmailVerificationCode(string email)
        {
            return await _loginRepository.ResetEmailVerificationCode(email);
        }

        public async Task<string> ResetPassword(string userName)
        {
            var result=await _loginRepository.ResetPassword(userName);
            if(result)
            {

            }
            return ValidationMessage.ResetPasswordEmailSentSuccess;
        }

        public async Task<bool> UpdateProfile(UserRequest request)
        {
            User user= _mapper.Map<User>(request);
            return await _loginRepository.UpdateProfile(user);
        }

        public async Task<string> VerifyEmail(string token)
        {
            var result=await _loginRepository.VerifyEmail(token);
            return result ? ValidationMessage.EmailVerificationSuccess : ValidationMessage.EmailVerificationFail;
        }
    }
}
