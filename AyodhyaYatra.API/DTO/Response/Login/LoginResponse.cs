using AyodhyaYatra.API.DTO.Response;

namespace AyodhyaYatra.API.DTO.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserResponse UserResponse { get; set; }
    }
}
