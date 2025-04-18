﻿using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Nombre {  get; set; } = string.Empty;
        [Required]
        public string PrimerApellido { get; set; } = string.Empty;
        [Required]
        public string SegundoApellido { get; set; } = string.Empty;
        public string Rol { get; set; } = "Admin";
    }
}
