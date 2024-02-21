namespace LVSaleSystem.API.DTO.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public int UserRole { get; set; }
    }
}
