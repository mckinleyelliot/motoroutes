namespace motoroutes.Models
{
    public class comment
    {
        public int commentId {get;set;}
        public int UserId {get;set;}
        public int rideId {get;set;}
        public User commentor {get;set;}
        public ride commentsss {get;set;}
    }
}