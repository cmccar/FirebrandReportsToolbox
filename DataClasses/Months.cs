using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrandReportsToolbox.DataClasses
{
    public class Months
    {
        private Dictionary<int, Month> monthNumsToMonth;
        public Dictionary<int, Month> MonthNumsToMonth
        {
            get { return monthNumsToMonth; }
            set { monthNumsToMonth = value; }
        }

        public Months()
        {
            monthNumsToMonth = new Dictionary<int, Month>();
        }
    }
}
