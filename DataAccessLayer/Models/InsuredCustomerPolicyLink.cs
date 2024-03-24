using DataAccessLayer;

namespace DataAccessLayer
{
    public class InsuredCustomerPolicyLink : IInsuredCustomerPolicyLink
    {
        public int PolicyLinkId { get; set; }
        public int InsuredCustomerId { get; set; }
        public int PolicyDetailsId { get; set; }
    }
}
