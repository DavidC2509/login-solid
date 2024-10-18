﻿using Core.Domain.Domain;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.UserAggregate
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;

        }

        internal User(string name, string password, string email, string? phone) : this()
        {
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
        }

        public static User CreateUser(string name, string password,string email, string? phone)
       => new(name,password,email,phone);
    }
}
