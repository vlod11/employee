namespace Common.Options
{
    public class MongoDbOptions
    {
        public string PositionsCollectionName { get; set; }
        public string EmployeesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}