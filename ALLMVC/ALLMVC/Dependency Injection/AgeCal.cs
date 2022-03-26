using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALLMVC.Dependency_Injection
{
    public class AgeCal : IAgeCal
    {
        public string GetAge(DateTime dateTime)
        {
            var value = DateTime.Now.Subtract(dateTime);
            DateTime age = DateTime.MinValue + value;
            return string.Format("{0} Years {1} months {2} Days", age.Year - 1, age.Month - 1, age.Day - 1);
        }
    }
}
