using ApiGateway.Models.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Models
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
