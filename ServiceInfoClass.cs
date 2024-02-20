using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace ServiceManagement
{
    internal class ServiceInfoClass
    {

        // Function to retrieve the description of a service
        public string GetServiceDescription(string serviceName)
        {
            string description = string.Empty;
            if (serviceName != null)
            {
                ManagementObject serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName)));
                try
                {
                    description = serviceObject["Description"].ToString();
                    return description;
                }
                catch (Exception ex)
                {
                    description = ex.Message; // or just leave it empty!
                }
            }

            // Return "N/A" if the description is not found
            return "N/A";
        }

    }
}
