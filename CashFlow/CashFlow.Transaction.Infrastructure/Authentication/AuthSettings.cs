namespace CashFlow.Transaction.Infrastructure.Authentication
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
