using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.BLL
{
    public class Harddrive
    {
        public long GetDiscspaceByDriveLetter(string DriveLetter)
        {
            DLL.Harddrive dataHarddrive = new DLL.Harddrive();
            return (dataHarddrive.GetDiscspaceByDriveLetter(DriveLetter));
        }

        public long GetDiscspaceLeftByDriveLetter(string DriveLetter)
        {
            DLL.Harddrive dataHarddrive = new DLL.Harddrive();
            return (dataHarddrive.GetDiscspaceLeftByDriveLetter(DriveLetter));
        }

        public string GetDiscSerialNumberByDriveLetter(string DriveLetter)
        {
            DLL.Harddrive dataHarddrive = new DLL.Harddrive();
            return (dataHarddrive.GetDiscSerialNumberByDriveLetter(DriveLetter));
        }

        public string GetBootDevice()
        {
            DLL.Harddrive dataHarddrive = new DLL.Harddrive();
            return (dataHarddrive.GetBootDevice());
        }

    }
}
