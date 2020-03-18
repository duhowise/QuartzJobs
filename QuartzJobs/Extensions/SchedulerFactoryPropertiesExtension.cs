using System.Collections.Specialized;

namespace QuartzJobs.Extensions
{
    public static class SchedulerFactoryPropertiesExtension
    {
        public static void AddJsonSerialiser(this NameValueCollection collection)
        {
            collection.Add("quartz.serializer.type", "json");
        }
        public static void AddBinarySerialiser(this NameValueCollection collection)
        {
            collection.Add("quartz.serializer.type", "binary");
        }
        public static void AddAdoDotNetJobStore(this NameValueCollection collection)
        {
            collection.Add("quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz");
        }
        public static void AddDefaultDataSource(this NameValueCollection collection)
        {
            collection.Add("quartz.jobStore.dataSource", "default");
        } 
        
        public static void AddSqlServerProvider(this NameValueCollection collection)
        {
            collection.Add("quartz.dataSource.default.provider", "SqlServer");
        }
        public static void AddConnectionString(this NameValueCollection collection,string connectionString)
        {
            collection.Add("quartz.dataSource.default.connectionString", connectionString);
        } 
        public static void AddClusteredJobStore(this NameValueCollection collection)
        {
            collection.Add("quartz.jobStore.clustered", "true");
        }
        public static void AddSqlServerDriverDelegate(this NameValueCollection collection)
        {
            collection.Add("quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz");
        }
    }
}