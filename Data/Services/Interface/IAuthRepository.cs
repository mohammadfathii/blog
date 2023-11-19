namespace Blog.Data.Services.Interface
{
    public interface IAuthRepository
    {
        string EncryptePassword(string password);
        bool CheckPassword(string HashPassword,string Password);
    }
}