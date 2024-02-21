namespace LVSaleSystem.API.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base($"Falha no login.")
        {
            StatusCode = 400;
        }

        public int StatusCode { get; }
    }
}
