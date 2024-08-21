using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myownplatform.Data;
using myownplatform.DTO;
using myownplatform.Entity;
using System.Security.Cryptography;
using System.Text;

namespace myownplatform.Controllers
{

    public class accountController : BaseController
    {
        private readonly DataContext context;

        public accountController(DataContext context)
        {
            this.context = context;
        }
        [HttpPost("register")]

        public async Task<ActionResult<AppUser>> register(registerDTO reg)
        {
            if(await exist(reg))
            {
                return BadRequest("already found");
            }
            using var hash=new HMACSHA512();
            AppUser user = new AppUser()
            {
                Name = reg.Name.ToLower(),
                passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(reg.password)),
                passwordSalt = hash.Key
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> login(loginDTO login)
        {
           AppUser user=await context.Users.FirstOrDefaultAsync(c=>c.Name==login.Name);
            if(user==null)
            {
                return Unauthorized("invalid username");
            }
            using var hash = new HMACSHA512(user.passwordSalt);
          var pass=  hash.ComputeHash(Encoding.UTF8.GetBytes(login.password));
            for(int i=0;i<pass.Length; i++)
            {
                if (pass[i] != user.passwordHash[i])
                    return Unauthorized("invalid password");
            }
            return Ok(user);
        }
        private async Task<bool> exist(registerDTO reg)
        {
            return await context.Users.AnyAsync(u=>u.Name == reg.Name.ToLower());
        }
    }
}
