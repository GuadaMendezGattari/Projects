using System;
using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(100), Required]
        public string Username { get; set; } = null!;

        [MaxLength(100), Required]
        public string Password { get; set; } = null!;
    }
}

