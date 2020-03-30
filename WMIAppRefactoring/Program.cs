using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using WMIAppRefactoring.BLL;

namespace WMIAppRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press H to view Harddrive info");
                Console.WriteLine("Press P to view Processor info");
                Console.WriteLine("Press R to view RAM info");
                Console.WriteLine("Press C to view Computer info");
                Console.WriteLine("Press S to view Service info");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'h':
                        BLL.Harddrive harddrive = new BLL.Harddrive();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter the drive letter for the drive you want to check:");
                        ConsoleKeyInfo driveToCheck = Console.ReadKey(true);

                        try
                        {
                            string driveToCheckKey = driveToCheck.KeyChar.ToString();

                            Console.WriteLine("Space: "+ByteToGB(harddrive.GetDiscspaceByDriveLetter(driveToCheckKey)) + " GB");
                            Console.WriteLine("Space left: "+ByteToGB(harddrive.GetDiscspaceLeftByDriveLetter(driveToCheckKey)) + " GB");
                            Console.WriteLine("Serial number:"+harddrive.GetDiscSerialNumberByDriveLetter(driveToCheck.KeyChar.ToString()));
                            Console.WriteLine("Boot device: "+harddrive.GetBootDevice());
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid drive");
                            Console.ReadKey();
                        }


                        break;

                    case 'p':
                        BLL.Processor processor = new BLL.Processor();
                        Console.ForegroundColor = ConsoleColor.Blue;

                        foreach (DLL.Processor processes in processor.GetCPUUsagePerCore())
                        {
                            Console.WriteLine(processes.CoreName+ " : " + processes.Usage);
                        }

                        Console.WriteLine(processor.GetCPUUsagePerCore().Count);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case 'r':
                        BLL.Ram ram = new BLL.Ram();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("VisibleMemory: " + ram.GetVisibleMemory() / 1024 + " MB");
                        Console.WriteLine("FreeMemory: " + ram.GetFreeMemory() / 1024 + " MB");
                        Console.WriteLine("VirtualMemory: " + ram.GetVirtualMemory() / 1024 + " MB");
                        Console.WriteLine("FreeVirtualMemory: " + ram.GetFreeVirtualMemory() / 1024 + " MB");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case 'c':
                        BLL.Computer computer = new BLL.Computer();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Organization: "+computer.GetOrganization());
                        Console.WriteLine("Operativ System: "+computer.GetOS());
                        Console.WriteLine("User: "+computer.GetUser());
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case 's':
                        BLL.Service service = new BLL.Service();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (DLL.Service services in service.GetServices())
                        {
                            Console.WriteLine(services.Name + " : " + services.Value);
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }
            }
        }

        static double ByteToGB(long bytes)
        {
            return (Math.Round(bytes / (1024D * 1024D * 1024D),2));
        }
    }
}
