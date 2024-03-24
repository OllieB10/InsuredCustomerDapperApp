using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DataManager
    {
        public List<Title> GetTitles()
        {
            DataConnection dataConnection = new DataConnection();

            using (IDbConnection connection = new SqlConnection(dataConnection.GetConnectionString()))
            {
                string sql = @"SELECT
                                     TITLEID,
                                     TITLEDESCRIPTION,
                                     TITLESEX 
                                 FROM 
                                     TITLE";

                List<Title> titles = connection.Query<Title>(sql).ToList();

                return titles;
            }
        }

        public IInsuredCustomerPolicyDetails GetInuredCustomerPolicyDetails(int policyDetailsId)
        {
            DataConnection dataConnection = new DataConnection();

            PolicyDetails policyDetails = new PolicyDetails();

            InsuredCustomerPolicyDetails polHolCusDetails = new InsuredCustomerPolicyDetails();

            InsuredCustomer insuredCustomer = new InsuredCustomer();

            Title title = new Title();

            using (IDbConnection connection = new SqlConnection(dataConnection.GetConnectionString()))
            {
                string sql = @"SELECT
                                     PD.POLICYDETAILSID, 
                                     PD.POLICYSTARTDATE, 
                                     PD.POLICYENDDATE,
                                     PD.CANCELLATIONDATE
                                 FROM
                                     POLICYDETAILS AS PD 
                                WHERE
                                     PD.POLICYDETAILSID = @PolicyDetailsId;";

                policyDetails = connection.Query<PolicyDetails>(sql, new { PolicyDetailsId = policyDetailsId }).FirstOrDefault();

                polHolCusDetails.PolicyDetails = policyDetails;

                sql = @"
                        SELECT
                              ICPL.INSUREDCUSTOMERID
                        FROM
                            INSUREDCUSTOMERPOLICYLINK AS ICPL
                        WHERE 
                             POLICYDETAILSID = @PolicyDetailsID;";

                int insuredCustomerId = connection.QuerySingle<int>(sql, new { PolicyDetailsID = policyDetails.PolicyDetailsId});

                sql = @"SELECT
                              IC.INSUREDCUSTOMERID,
                              IC.FIRSTNAME,
                              IC.LASTNAME,
                              IC.TITLEID,
                              IC.SEX,
                              IC.DATEOFBIRTH,
                              IC.EMAIL 
                       FROM
                             INSUREDCUSTOMER AS IC
                       WHERE 
                            IC.INSUREDCUSTOMERID = @InsuredCustomerId;";

                insuredCustomer = connection.Query<InsuredCustomer>(sql, new { InsuredCustomerId = insuredCustomerId}).FirstOrDefault();

                sql = @"SELECT 
                              T.TITLEID,
                              T.TITLEDESCRIPTION,
                              T.TITLESEX
                         FROM
                              TITLE AS T
                         WHERE
                              T.TITLEID = @Title; ";

                title = connection.Query<Title>(sql, new {Title = insuredCustomer.TitleId}).FirstOrDefault();

                insuredCustomer.Title = title;

                polHolCusDetails.InsuredCustomer = insuredCustomer;             
            }

            return polHolCusDetails;
        }

        public async Task<List<InsuredCustomer>> GetInsuredCustomerAsync()
        {
            DataConnection dataConnection = new DataConnection();

            List<InsuredCustomer> insuredCustomers = new List<InsuredCustomer>();
            List<Title> titles = new List<Title>();

            using (IDbConnection connection = new SqlConnection(dataConnection.GetConnectionString()))
            {
                string queryInsuredCustomers = @"SELECT
                                                       IC.INSUREDCUSTOMERID,
                                                       IC.FIRSTNAME,
                                                       IC.LASTNAME,
                                                       IC.TITLEID,
                                                       IC.SEX,
                                                       IC.DATEOFBIRTH,
                                                       IC.EMAIL 
                                                   FROM
                                                       INSUREDCUSTOMER AS IC";
                                 

                string queryTitles = @"SELECT 
                                             T.TITLEID,
                                             T.TITLEDESCRIPTION,
                                             T.TITLESEX
                                         FROM
                                             TITLE AS T;";

                IEnumerable<InsuredCustomer> customer = await connection.QueryAsync<InsuredCustomer>(queryInsuredCustomers);
                IEnumerable<Title> titlesReturned = await connection.QueryAsync<Title>(queryTitles);

                insuredCustomers = customer.AsList();
                titles = titlesReturned.AsList();

                foreach (InsuredCustomer customerInsured in insuredCustomers)
                {
                    customerInsured.Title = titles.FirstOrDefault(t => t.TitleId == customerInsured.TitleId);
                }
            }

            return insuredCustomers;
        }     
    }
}
