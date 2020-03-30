using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIAppRefactoring.BLL
{
    public class Processor
    {
        public List<DLL.Processor> GetCPUUsagePerCore()
        {
            DLL.Processor dataProcessor = new DLL.Processor();
            return (dataProcessor.GetCPUUsagePerCore());
        }
    }
}
