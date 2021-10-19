using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserPasswordDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 8)]
        public string CurrentPassword { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 8)]
        public string NewPassword { get; set; }  
        [Required]
        [EmailAddress]
        public string Email { get; set; }            
    }
}