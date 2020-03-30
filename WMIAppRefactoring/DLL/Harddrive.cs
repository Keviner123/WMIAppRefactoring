using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIAppRefactoring.DLL
{
    public class Harddrive
    {
        /// <summary>
        /// Returns the disc space in bytes on a given drive
        /// </summary>
        public long GetDiscspaceByDriveLetter(string DriveLetter)
        {
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();
            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select Size,Name from Win32_LogicalDisk where Name = '" + DriveLetter + ":'");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            if (managementObjectCollection.Count != 0)
            {
                foreach (ManagementObject managementObject in managementObjectCollection)
                {
                    return (Convert.ToInt64(managementObject["Size"]));
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the remaining disc space in bytes on a given drive
        /// </summary>
        public long GetDiscspaceLeftByDriveLetter(string DriveLetter)
        {
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();
            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select FreeSpace,Name from Win32_LogicalDisk where Name = '" + DriveLetter + ":'");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            if (managementObjectCollection.Count != 0)
            {
                foreach (ManagementObject managementObject in managementObjectCollection)
                {
                    return (Convert.ToInt64(managementObject["FreeSpace"]));
                }
            }
            return -1;
        }


        /// <summary>
        /// Returns the serial number of a given drive
        /// </summary>
        public string GetDiscSerialNumberByDriveLetter(string DriveLetter)
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + DriveLetter + ":\"");
            managementObject.Get();
            return managementObject["VolumeSerialNumber"].ToString();
        }

        /// <summary>
        /// Returns the boot drive
        /// </summary>
        public string GetBootDevice(){

            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                return(m["BootDevice"].ToString());
            }

            return null;
        }

    }

}
