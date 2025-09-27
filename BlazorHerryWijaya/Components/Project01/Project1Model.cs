namespace BlazorHerryWijaya.Components.Project01
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CompanyInventory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }

        public int StockQuantity { get; set; }

        public Company Company { get; set; }
        public Product Product { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CompanyInventory> Inventories { get; set; } = new();
    }
}
