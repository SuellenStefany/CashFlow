using System.Security.Cryptography;
using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Domain.Entities;

namespace CashFlow.Transaction.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IAuthService authService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authService = authService;
        }
        public async Task<bool> CreateUser(CreateUserDto createUser)
        {
            try
            {
                byte[] saltBytes = RandomNumberGenerator.GetBytes(32);
                string salt = Convert.ToBase64String(saltBytes);
                string hash = _passwordHasher.HashPassword(createUser.Password, saltBytes);

                var resultUser = new User(createUser.Username, hash, salt);
                await _userRepository.CreateUser(resultUser);
                return true;
            }
            catch
            {
                return false;
            }          
        }
        public async Task<TokenUserDto>? LoginUser(LoginUserDto loginUser)
        {
            var verifyUser = await _userRepository.GetUserByUsername(loginUser.Username);
            if(verifyUser == null)
            {
                return null;
            }
            var hash = _passwordHasher.HashPassword(loginUser.Password, Convert.FromBase64String(verifyUser.PasswordSalt));
            if (hash == verifyUser.PasswordHash)
            {
                var generateToken =_authService.GenerateToken(verifyUser.Id); 
                return new TokenUserDto
                {
                    Token = generateToken
                };
            }
            return null;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }
    }
}
