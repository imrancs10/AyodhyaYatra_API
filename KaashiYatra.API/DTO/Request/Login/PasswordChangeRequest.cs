﻿namespace KaashiYatra.API.DTO.Request
{
    public class PasswordChangeRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string UserName { get; set; }
    }
}
