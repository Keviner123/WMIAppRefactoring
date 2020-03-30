using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.DLL
{
    public class Ram
    {
        /// <summary>
        /// Returns the amount of memory in the system as bytes
        /// </summary>
        public long GetVisibleMemory()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                return(Convert.ToInt64(result["TotalVisibleMemorySize"]));
            }
            return -1;
        }

        /// <summary>
        /// Returns the amount of free memory in the system as bytes
        /// </summary>
        public long GetFreeMemory()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                return (Convert.ToInt64(result["FreePhysicalMemory"]));
            }
            return -1;
        }

        /// <summary>
        /// Returns the amount of virtual memory in the system as bytes
        /// </summary>
        public long GetVirtualMemory()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                return (Convert.ToInt64(result["TotalVirtualMemorySize"]));
            }
            return -1;
        }

        /// <summary>
        /// Returns the amount of free virtual memory in the system as bytes
        /// </summary>
        public long GetFreeVirtualMemory()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                return (Convert.ToInt64(result["FreeVirtualMemory"]));
            }
            return -1;
        }
    }
}
