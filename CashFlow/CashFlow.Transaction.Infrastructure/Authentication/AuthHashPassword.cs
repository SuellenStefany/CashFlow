using System.Text;
using CashFlow.Transaction.Application.Interfaces;
using Konscious.Security.Cryptography;

namespace CashFlow.Transaction.Infrastructure.Authentication
{
        public class AuthHashPassword : IPasswordHasher
        {
            public string HashPassword(string password, byte[] salt)
            {
                using (var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
                {
                    argon2.Salt = salt;
                    argon2.DegreeOfParallelism = 8; 
                    argon2.MemorySize = 65536; 
                    argon2.Iterations = 4; 

                    byte[] hashBytes = argon2.GetBytes(32);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }
}
