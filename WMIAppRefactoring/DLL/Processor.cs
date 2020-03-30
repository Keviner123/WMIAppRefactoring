using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.DLL
{
    public class Processor
    {
        public string CoreName { get; set; }
        public int Usage { get; set; }

        /// <summary>
        /// Returns the CPU usage per core in the system
        /// </summary>
        public List<Processor> GetCPUUsagePerCore()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");

            List<Processor> processorUsage = new List<Processor>();
            foreach (ManagementObject obj in searcher.Get())
            {
                Processor tempCoreUsage = new Processor();
                tempCoreUsage.CoreName = obj["Name"].ToString();
                tempCoreUsage.Usage = Convert.ToInt32(obj["PercentProcessorTime"]);
                processorUsage.Add(tempCoreUsage);
            }
            return (processorUsage);
        }
    }
}
