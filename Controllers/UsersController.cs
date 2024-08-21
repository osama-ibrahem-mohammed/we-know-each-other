using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myownplatform.Data;
using myownplatform.Entity;

namespace myownplatform.Controllers
{
   
    public class UsersController : BaseController
    {
        private readonly DataContext context;

        public UsersController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable< AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("id")]
        public async Task< ActionResult<AppUser>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}
