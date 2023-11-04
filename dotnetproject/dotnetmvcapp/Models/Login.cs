using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnetmvcapp.Models
{
    public class Login
    {
        [Key]
        
       public int LoginID {get; set;}
       
       
       [Required(ErrorMessage = "Email is Required")]
       [Display(Name = "Email ID")]
       [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
       public string Email{get; set;}

       [Required(ErrorMessage ="Password is required")]
       [Display(Name = "Password")]
       [DataType(DataType.Password)]
       public string Password{get; set;}
    }
}