﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NewUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "RegUser";
    }

    public enum UserRoles
    {
        Admin,
        RegUser
    }
}