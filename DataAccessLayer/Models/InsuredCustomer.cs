
namespace DataAccessLayer
{
    public class InsuredCustomer : IInsuredCustomer
    {
        public int InsuredCustomerId { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public int TitleId { get; set; }
        public Title Title { get; set; } = null;
        public string Sex { get; set; } = null;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null;
    }
}
