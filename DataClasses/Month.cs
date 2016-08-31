using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebrandReportsToolbox.DataClasses
{
    public class Month
    {
        private string name;
        public string Name { get { return name; } }

        private string filePath;
        public string FilePath { get { return filePath; } }

        private DateTime startTime;
        public DateTime StartTime { get { return startTime; } }

        private DateTime endTime;
        public DateTime EndTime { get { return endTime; } }

        public Month(string _name, string _filePath, DateTime _startTime, DateTime _endTime)
        {
            name = _name;
            filePath = _filePath;
            startTime = _startTime;
            endTime = _endTime;
        }
    }
}
