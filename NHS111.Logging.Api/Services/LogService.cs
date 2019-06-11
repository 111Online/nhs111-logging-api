using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace NHS111.Logging.Api.Services
{
    public class LogService : ILogService
    {
        private readonly List<CloudTable> _tables = new List<CloudTable>();
        private readonly CloudStorageAccount _storageAccount;
        private readonly string _defaultStorageTableName;

        public LogService(string accountName, string accountKey, string storageTable) : this(new StorageCredentials(accountName, accountKey), storageTable)
        {
        }

        public LogService(StorageCredentials credentials, string storageTable)
        {
            _storageAccount = new CloudStorageAccount(credentials, true);
            _defaultStorageTableName = storageTable;
        }

        public async Task Log<T>(T entity) where T : ITableEntity
        {
            var insertOperation = TableOperation.Insert(entity);
            var tableName = $"{_defaultStorageTableName}{DateTime.UtcNow:yyyyMM}";
            await GetTable(tableName).ExecuteAsync(insertOperation);
        }

        private CloudTable GetTable(string storageTable)
        {
            return _tables.Exists(t => t.Name == storageTable) ? _tables.First(t => t.Name == storageTable) : SetTableStorage(storageTable);
        }

        private CloudTable SetTableStorage(string storageTable)
        {
            var client = _storageAccount.CreateCloudTableClient();
            var table = client.GetTableReference(storageTable);
            table.CreateIfNotExistsAsync();
            _tables.Add(table);
            return table;
        }
    }

    public interface ILogService
    {
        Task Log<T>(T entity) where T : ITableEntity;
    }
}
