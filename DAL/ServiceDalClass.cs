using ServiceManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManagement.DAL
{
    internal class ServiceDalClass
    {
        //list of service details class
        List<ServiceDetailsClass> serviceDetails = new List<ServiceDetailsClass>();
        public static string connectionstring = "Data Source=LAPTOP-CMODSAPH\\SQLEXPRESS;Initial Catalog=Infinnium;Integrated Security=True;";

        //method to get all service details
        public List<ServiceDetailsClass> GetAllServiceDetails()
        {
           using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from ServiceDetails", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ServiceDetailsClass service = new ServiceDetailsClass();
                    service.ServiceName = rdr["ServiceName"].ToString();
                    service.ServiceDescription = rdr["ServiceDescription"].ToString();
                    service.ServiceStartType = rdr["ServiceStartType"].ToString();
                    service.ServiceDisplayName = rdr["ServiceDisplayName"].ToString();
                    serviceDetails.Add(service);
                }
            }
            return serviceDetails;
        }

        #region Insert Service Details
        public void InsertServiceDetails(ServiceDetailsClass serviceDetails)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ServiceDetails(ServiceName,ServiceDescription,ServiceStartType,ServiceDisplayName) values(@ServiceName,@ServiceDescription,@ServiceStartType,@ServiceDisplayName)", con);
                cmd.Parameters.AddWithValue("@ServiceName", serviceDetails.ServiceName);
                cmd.Parameters.AddWithValue("@ServiceDescription", serviceDetails.ServiceDescription);
                cmd.Parameters.AddWithValue("@ServiceStartType", serviceDetails.ServiceStartType);
                cmd.Parameters.AddWithValue("@ServiceDisplayName", serviceDetails.ServiceDisplayName);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
