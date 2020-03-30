using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.DLL
{
    public class Computer
    {
        /// <summary>
        /// Returns the current user logged in 
        /// </summary>
        public string GetUser() {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                return (result["RegisteredUser"].ToString());
            }
            return null;
        }

        /// <summary>
        /// Returns the organization the user is tied to
        /// </summary>
        public string GetOrganization() {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                return (result["Organization"].ToString());
            }
            return null;
        }

        /// <summary>
        /// Returns the os that the user is running
        /// </summary>
        public string GetOS() {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                return (result["Name"].ToString());
            }
            return null;
        }
    }
}
