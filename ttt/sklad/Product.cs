namespace sklad.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        // Можно добавить другие поля: категория, etc.
    }
}