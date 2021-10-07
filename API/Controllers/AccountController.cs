using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Cryptography;
using API.Entities;
using API.Data;
using System.Text;
using System;

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
        public async Task<ActionResult<AppUser>> Register(string username, string password, string firstname, string lastname)
        {
            using var hmac = new HMACSHA512(); //using keyword for disposable object

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                FirstName = firstname,
                LastName = lastname,
                CreateDT = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}