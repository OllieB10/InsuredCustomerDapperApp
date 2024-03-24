namespace DataAccessLayer
{
    public class Title : ITitle
    {
        public int TitleId { get; set; }
        public string TitleDescription { get; set; } = null;
        public string TitleSex { get; set; } = null;
    }
}
