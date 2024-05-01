using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OnlineStoreProject.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "OnlineShopAuthServer";
        public const string AUDIENCE = "OnlineShopUser";
        public const string KEY = "MySuperSecret_key#forOnlineShop!123#@#@#@#";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
