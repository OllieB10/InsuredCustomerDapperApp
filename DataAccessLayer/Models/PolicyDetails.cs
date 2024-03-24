
namespace DataAccessLayer
{
    public class PolicyDetails : IPolicyDetails
    {
        public int PolicyDetailsId { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public DateTime CancellationDate { get; set; }
    }
}
