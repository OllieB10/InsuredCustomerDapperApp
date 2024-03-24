
namespace DataAccessLayer
{
    public interface IInsuredCustomer
    {
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int InsuredCustomerId { get; set; }
        string Sex { get; set; }
        string LastName { get; set; }
        Title Title { get; set; }
        int TitleId { get; set; }
    }
}