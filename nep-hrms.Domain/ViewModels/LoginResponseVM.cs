namespace nep_hrms.Domain.ViewModels
{
    public class LoginResponseVM
    {
        public string UserId { get; set; }
        public string PassToken { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
