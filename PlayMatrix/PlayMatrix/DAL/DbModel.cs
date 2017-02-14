using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;

namespace PlayMatrix.DAL
{
    public class DbModel<T> : IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        DocumentClient client;
        string dbName = "DB_Employees";
        FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

        public DbModel(string endpointUri, string primaryKey, string dbName)
        {

            client = new DocumentClient(new Uri(endpointUri), primaryKey);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private string CollName
        {
            get
            {
                var type = typeof(T);
                return "Coll" + type.Name;
            }
        }

        private Uri CollUri
        {
            get
            {
                return UriFactory.CreateDocumentCollectionUri(dbName, CollName);
            }
        }

        private Uri DocUri(string id)
        {
            return UriFactory.CreateDocumentUri(dbName, CollName, id);
        }

        #region Initialize
        public async Task Initialize()
        {
            await CreateDatabaseIfNotExists();
            await CreateDocumentCollectionIfNotExists();
        }

        private async Task CreateDatabaseIfNotExists()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(dbName));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = dbName });
                }
                else
                {
                    logger.Error(de);
                }
            }
        }

        private async Task CreateDocumentCollectionIfNotExists()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(CollUri);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    DocumentCollection collectionInfo = new DocumentCollection
                    {
                        Id = CollName,
                        IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 })
                    };
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(dbName),
                        new DocumentCollection { Id = CollName },
                        new RequestOptions { OfferThroughput = 400 });
                }
                else
                {
                    logger.Error(de);
                }
            }
        }
        #endregion

        public T Get(string empid)
        {
            var query = string.Format(@"id == ""{0}""", empid);
            foreach (var obj in All.Where(query))
                return obj;
            return default(T);
        }

        public T First()
        {
            foreach (var obj in All.Take(1))
                return obj;
            return default(T);
        }

        public IOrderedQueryable<T> All
        {
            get
            {
                return client.CreateDocumentQuery<T>(CollUri, queryOptions);
            }
        }

        public async Task<T> Add(IObj obj)
        {
            try
            {
                var response = await client.CreateDocumentAsync(CollUri, obj);
                return JsonConvert.DeserializeObject<T>(response.Resource.ToString());
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return default(T);
        }

        public async Task<T> Update(IObj obj)
        {
            try
            {
                var response = await client.ReplaceDocumentAsync(DocUri(obj.id), obj);
                return JsonConvert.DeserializeObject<T>(response.Resource.ToString());
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    return await Add(obj);
                }
            }
            return default(T);
        }

        public async Task<string> Remove(string id)
        {
            try
            {
                var response = await client.DeleteDocumentAsync(DocUri(id));
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return id;
        }
    }
    public interface IObj
    {
        string id { get; set; }
    }
}