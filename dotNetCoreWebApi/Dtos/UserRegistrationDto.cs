using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace dotNetCoreWebApi.Dtos
{
    public class UserRegistrationDto
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(20,MinimumLength = 6,ErrorMessage = "Password must be between 6 to 20 characters.")]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string KnownAs { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }

        public UserRegistrationDto()
        {
            CreatedAt = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
