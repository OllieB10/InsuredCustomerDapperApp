namespace DataAccessLayer
{
    public interface IInsuredCustomerPolicyLink
    {
        int InsuredCustomerId { get; set; }
        int PolicyDetailsId { get; set; }
        int PolicyLinkId { get; set; }
    }
}