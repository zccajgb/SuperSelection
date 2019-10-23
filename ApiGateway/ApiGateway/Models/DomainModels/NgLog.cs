namespace ApiGateway.Models.DomainModels
{
    using System;

    public class NgLog
    {
        public NgLog(string message, int level, DateTime timestamp, string fileName, string lineNumber)
        {
            this.Message = message;
            this.Level = level;
            this.Timestamp = timestamp;
            this.FileName = fileName;
            this.LineNumber = lineNumber;
        }

        public string Message { get; set; }

        public int Level { get; set; }

        public DateTime Timestamp { get; set; }

        public string FileName { get; set; }

        public string LineNumber { get; set; }
    }
}
