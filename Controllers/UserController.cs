using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Blog.Controllers
{
    public class UserController
    {
        [HttpGet("/enc/{password}")]
        public string EncryptePassword(string? password){

            string pass = BCrypt.Net.BCrypt.HashPassword(password);
            // return (BCrypt.Net.BCrypt.Verify("123",pass)) == true ? "yes" : "no" ;          
            return pass;
            // byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            // string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            //     password : password!,
            //     salt : salt,
            //     prf : KeyDerivationPrf.HMACSHA256,
            //     iterationCount : 100000,
            //     numBytesRequested : 256 / 8
            // ));
            // return hashed;
        }




    }
}