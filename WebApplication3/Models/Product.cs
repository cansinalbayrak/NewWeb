namespace WebApplication3.Models
{
    public class Product
    {
        public Product(int ıd, string name, string description, int price, string ımgLink)
        {
            Id = ıd;
            Name = name;
            Description = description;
            Price = price;
            ImgLink = ımgLink;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImgLink { get; set; }
    }
}
