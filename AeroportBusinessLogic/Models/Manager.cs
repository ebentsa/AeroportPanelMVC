using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AeroportBusinessLogic.Enums;

namespace AeroportBusinessLogic.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RoleEnum Role { get; set; }

    }
}