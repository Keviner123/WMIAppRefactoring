using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.DLL
{
    public class Service
    {
        public string Name { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// Returns the services on the system
        /// </summary>
        public List<Service> GetServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            List<Service> Services = new List<Service>();

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {


                        Service TempService = new Service();
                        TempService.Name = serviceProperty.Name;
                        TempService.Value = serviceProperty.Value.ToString();
                        Services.Add(TempService);

                    }
                }
            }
            return(Services);
        }
    }
}
