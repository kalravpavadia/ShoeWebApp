using Microsoft.AspNetCore.Mvc;
using ShoeWebApp.attributes;
using System.ComponentModel.DataAnnotations;

namespace ShoeWebApp.Models
{
    public class UserViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; } = string.Empty;
        
        public string UserLastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [Remote("CheckDuplicate","User","UserEmail",HttpMethod ="GET")]
        public string UserEmail { get; set; } 
        [Required]
        [MaxLength(10, ErrorMessage = "too long bruv")]
        [MinLength(10, ErrorMessage = "too long bruv")]
        public string UserPhone { get; set; } 
        [Required]
        [MinLength(10, ErrorMessage = "too long bruv")]
        public string UserPassword { get; set; } 


    }
}
