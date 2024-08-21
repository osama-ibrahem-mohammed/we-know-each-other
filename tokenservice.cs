using Microsoft.IdentityModel.Tokens;
using myownplatform.Entity;
using myownplatform.Interface;
using System.Text;

namespace myownplatform
{
    public class tokenservice : ITokenService
    {
        private readonly SymmetricSecurityKey key;
        public tokenservice(IConfiguration config)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));  
        }
        public string createtoken(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
