﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Inlamning_2.Models.Data
{
    public class UserProfileEntity 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; } = string.Empty;

        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; } = string.Empty;


        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
