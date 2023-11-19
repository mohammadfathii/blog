using Blog.Data.Services.Interface;

namespace Blog.Data.Services
{
    public class AuthRepository : IAuthRepository
    {
        bool IAuthRepository.CheckPassword(string hashPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashPassword);
        }

        string IAuthRepository.EncryptePassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}