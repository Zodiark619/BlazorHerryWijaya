namespace BlazorHerryWijaya.Components.Project01
{
    public class CompanyInventoryDtoSave
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
    }
    public class ProductDtoSave
    {
        public string Name { get; set; }

    }
    public class CompanyDtoSave
    {
        public string Name { get; set; }

    }


    /////////////////////////////////////
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<CompanyInventoryDto> Inventories { get; set; } = new();
    }

    public class CompanyInventoryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }

        public string ProductName { get; set; } = string.Empty; // flattened, no EF nav property
    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
   /// <summary>
   /// 
   /// </summary>
    //public class AddCompanyInventoryViewModel
    //{
    //    public int CompanyId { get; set; }  
    //    public int ProductId { get; set; }
    //    public int Quantity { get; set; }


    //}
}
