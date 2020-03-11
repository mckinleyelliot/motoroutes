using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using motoroutes.Models;

namespace motoroutes.Models

{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [Display(Name="First Name: ")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name: ")]
        public string LastName {get;set;}
        [Required]
        [Display(Name="Email : ")]
        [EmailAddress]
        public string Email {get;set;}


        [Required]
        [Display(Name="Password: ")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [Display(Name="Confirm Password: ")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ComparePassword {get;set;}
        
        public List<ride> createdrides {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}