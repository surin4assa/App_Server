using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Crytography
using API.Entities;
using API.Data;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                PasswordSalt = hmac.key;
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}