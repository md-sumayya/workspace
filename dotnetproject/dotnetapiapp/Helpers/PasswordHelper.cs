using System.Text;
using System.Security.Cryptography;

namespace dotnetapiapp.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateSalt(){
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }

        public static string ComputeHash(string password,string salt){
            using var sha256 = SHA256.Create();
            var saltedPassword = $"{password}{salt}";
            var byteValue = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(hash);
        }
    }
}