using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.BLL
{
    public class Computer
    {
        public String GetUser()
        {
            DLL.Computer dataComputer = new DLL.Computer();
            return (dataComputer.GetUser());
        }

        public String GetOrganization()
        {
            DLL.Computer dataComputer = new DLL.Computer();
            return (dataComputer.GetOrganization());
        }

        public String GetOS()
        {
            DLL.Computer dataComputer = new DLL.Computer();
            return (dataComputer.GetOS());
        }

    }
}
