
namespace DataAccessLayer
{
    public interface IPolicyDetails
    {
        DateTime CancellationDate { get; set; }
        DateTime PolicyEndDate { get; set; }
        int PolicyDetailsId { get; set; }
        DateTime PolicyStartDate { get; set; }
    }
}