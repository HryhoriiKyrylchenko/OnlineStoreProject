namespace OnlineStoreProject.Models.Database.SupportClasses
{
    public class ProductDetail
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ProductDetail(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
