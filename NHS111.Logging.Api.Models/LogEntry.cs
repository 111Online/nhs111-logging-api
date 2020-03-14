using System;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace NHS111.Logging.Api.Models
{
    public class LogEntry : TableEntity
    {
        public LogEntry()
        {
            var now = DateTime.UtcNow;
            PartitionKey = $"{now.Hour}";
            RowKey = $"{now:dd HH:mm:ss.fff}-{Guid.NewGuid()}";
        }

        public LogEntry(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
    }
}
