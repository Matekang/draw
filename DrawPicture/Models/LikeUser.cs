namespace DrawPicture.Models
{
    public class LikeUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DrawId { get; set; }
        public DateTime LikedDate { get; set; }
    }
}
