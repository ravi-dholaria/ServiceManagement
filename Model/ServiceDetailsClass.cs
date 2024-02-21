using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManagement.Model
{
    internal class ServiceDetailsClass
    {
        public string ServiceName {get; set;}
        public string ServiceDescription { get; set;}
        public string ServiceStartType { get; set;}
        public string ServiceDisplayName { get; set;}
    }
}
