namespace SkeletonNetCore.Services.Models
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string img { get; set; }

        public int review { get; set; }
        public Product()
        {
        }
    }
}