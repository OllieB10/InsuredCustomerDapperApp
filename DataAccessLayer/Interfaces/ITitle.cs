namespace DataAccessLayer
{
    public interface ITitle
    {
        string TitleDescription { get; set; }
        int TitleId { get; set; }
        string TitleSex { get; set; }
    }
}