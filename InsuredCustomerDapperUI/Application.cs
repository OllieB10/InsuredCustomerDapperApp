using DataAccessLayer;

namespace InsuredCustomerDapperUI
{
    public static class Application
    {
        public static void GetTitles()
        {
            DataManager dataManager = new DataManager();

            List<Title> titles = dataManager.GetTitles();

            foreach (Title title in titles)
            {
                Console.WriteLine($"{title.TitleId}, {title.TitleDescription}, {title.TitleSex}");
            }
        }

        public static void GetCustomerInsuranceDetails()
        {
            DataManager dataManager = new DataManager();

            IInsuredCustomerPolicyDetails insuredCustomerDetails = dataManager.GetInuredCustomerPolicyDetails(2);

            Console.WriteLine($"InsuredCustomerId:  {insuredCustomerDetails.InsuredCustomer.InsuredCustomerId} " +
                              $"TitleId:  {insuredCustomerDetails.InsuredCustomer.TitleId}" +
                              $"TitleDescription: {insuredCustomerDetails.InsuredCustomer.Title.TitleDescription}, " +
                              $"First name:  {insuredCustomerDetails.InsuredCustomer.FirstName}," +
                              $"Last name:  {insuredCustomerDetails.InsuredCustomer.LastName}, " +
                              $"Date of birth:  {insuredCustomerDetails.InsuredCustomer.DateOfBirth}, " +
                              $"Sex:  {insuredCustomerDetails.InsuredCustomer.Sex}, " +
                              $"Email Address:  {insuredCustomerDetails.InsuredCustomer.Email}, ");
            Console.WriteLine();
            Console.WriteLine($"PolicyDetailsId:  {insuredCustomerDetails.PolicyDetails.PolicyDetailsId}" +
                              $"Policy Start Date:  {insuredCustomerDetails.PolicyDetails.PolicyStartDate.ToString()}" +
                              $"Policy End Date:  {insuredCustomerDetails.PolicyDetails.PolicyEndDate.ToString()}" +
                              $"Policy Cancellation Date:  {insuredCustomerDetails.PolicyDetails.CancellationDate.ToString()}");
        }

        public async static void GetInsuredCustomerPolicyDetails()
        {
            DataManager dataManager = new DataManager();

            List<InsuredCustomer> insuredCustomers = await dataManager.GetInsuredCustomerAsync();

            foreach (InsuredCustomer customer in insuredCustomers)
            {
                Console.WriteLine($"InsuredCustomerId:  {customer.InsuredCustomerId}");
                Console.WriteLine($"Title Description:  {customer.Title.TitleDescription}");
                Console.WriteLine($"First Name:  {customer.FirstName}");
                Console.WriteLine($"Last Name:  {customer.LastName}");
                Console.WriteLine($"Sex:  {customer.Sex}");
                Console.WriteLine($"Date of Birth:  {customer.DateOfBirth.ToString()}");
                Console.WriteLine($"Email Address:  {customer.Email}");
                Console.WriteLine();
            }       
        }
    }
}
