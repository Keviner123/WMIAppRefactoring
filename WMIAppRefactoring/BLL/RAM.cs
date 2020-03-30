using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.BLL
{
    public class Ram
    {
        public long GetVisibleMemory()
        {
            DLL.Ram dataRam = new DLL.Ram();
            return (dataRam.GetVisibleMemory());
        }

        public long GetFreeMemory()
        {
            DLL.Ram dataRam = new DLL.Ram();
            return (dataRam.GetFreeMemory());
        }

        public long GetVirtualMemory()
        {
            DLL.Ram dataRam = new DLL.Ram();
            return (dataRam.GetVirtualMemory());
        }

        public long GetFreeVirtualMemory()
        {
            DLL.Ram dataRam = new DLL.Ram();
            return (dataRam.GetFreeVirtualMemory());
        }
    }
}
