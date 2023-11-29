using KaashiYatra.API.DTO.Response;

namespace KaashiYatra.API.DTO.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserResponse UserResponse { get; set; }
    }
}
