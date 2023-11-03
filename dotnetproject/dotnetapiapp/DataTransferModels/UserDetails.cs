using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Models
{
    public class UserDetails
    {
        public UserDetails(){

        }
        public UserDetails(User model){
            UserName = model.UserName;
            UserRole = model.UserRole;
            Email = model.Email;
            PhoneNumber = model.PhoneNumber;
            Id = model.Id;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role UserRole { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}