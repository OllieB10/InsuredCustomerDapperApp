
namespace DataAccessLayer
{
    public class InsuredCustomerPolicyDetails : IInsuredCustomerPolicyDetails
    {
        public InsuredCustomer InsuredCustomer { get; set; } = null;
        public PolicyDetails PolicyDetails { get; set; } = null;
    }
}
