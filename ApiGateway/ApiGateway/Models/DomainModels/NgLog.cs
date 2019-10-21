using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Models.DomainModels
{
    public class NgLog
    {
        public NgLog(string message, int level, DateTime timestamp, string fileName, string lineNumber)
        {
            Message = message;
            Level = level;
            Timestamp = timestamp;
            FileName = fileName;
            LineNumber = lineNumber;
        }

        public string Message {get; set;}
        public int Level { get; set; }
        public DateTime Timestamp { get; set; }
        public string FileName { get; set; }
        public string LineNumber { get; set; }
    }
}
