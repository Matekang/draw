namespace DrawPicture.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? FolderName { get; set; }
        public int? Folder { get; set; }
        
    }
}
