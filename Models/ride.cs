using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace motoroutes.Models
{
    public class ride
    {
        [Key]
        public int rideId {get;set;}

        [Required(ErrorMessage="Please provide a url to a hosted KML file ")]
        public string kml_url {get; set;}

        [Required(ErrorMessage="Please Provide a name for the route")]
        [Display(Name="ridename: ")]
        public string ridename {get; set;}

        [Required(ErrorMessage="Please list a city near the ride")]
        [Display(Name="ridecity ")]
        public string ridecity {get;set;}


        [Display(Name="ridedesc: ")]
        public string ridedesc {get;set;}

        public int UserId {get;set;}

        public User Creator {get;set;}
        public List<comment> commentlist {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}