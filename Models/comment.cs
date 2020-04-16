using System;
using System.ComponentModel.DataAnnotations;

namespace motoroutes.Models
{
    public class comment
    {
        [Key]
        public int commentId {get;set;}
        public int rideId {get;set;}
        public ride ride {get;set;}
        [Required]
        [MinLength(4, ErrorMessage="Comment must be at least 4 characters")]
        [MaxLength(200, ErrorMessage="Too long")]
        public string commentcontent {get;set;}
        [Required]
        [MinLength(3, ErrorMessage="Name must be at least 4 characters")]
        [MaxLength(20, ErrorMessage="Too long")]
        public string commentcreator {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}