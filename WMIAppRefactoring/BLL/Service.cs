using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.BLL
{
    public class Service
    {
        public List<DLL.Service> GetServices()
        {
            DLL.Service dataService = new DLL.Service();
            return (dataService.GetServices());
        }
    }
}
