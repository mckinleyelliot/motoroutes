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
        
        [Required(ErrorMessage="Please list a state near the ride")]
        [Display(Name="ridestate ")]
        public string ridestate {get;set;}


        [Display(Name="ridedesc: ")]
        public string ridedesc {get;set;}
        public List<comment> comments {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}