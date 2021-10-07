using System;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; } // use id as entity framework recognize it
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreateDT { get; set; }
    }
}