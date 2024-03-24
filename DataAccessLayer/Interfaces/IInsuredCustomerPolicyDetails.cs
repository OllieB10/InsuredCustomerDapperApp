namespace DataAccessLayer
{
    public interface IInsuredCustomerPolicyDetails
    {
        InsuredCustomer InsuredCustomer { get; set; }
        PolicyDetails PolicyDetails { get; set; }
    }
}