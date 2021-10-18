using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class OnlineUser
    {
        public OnlineUser()
        {
        } 

        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public string Username {get; set;}
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        
    }
}