using System.Text;

namespace Api.Helpers;

public static class PasswordHelper
{
    public static string Encrypt(string pass){
        byte[] data = Encoding.ASCII.GetBytes(pass);
        data = System.Security.Cryptography.SHA256.HashData(data);
        string hash = Encoding.ASCII.GetString(data);

        return hash;
    }
}