namespace DeployOnVM.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }    
        public int Quantity { get; set; }
    }

    public class ProductResponse
    {
        public bool IsBeta { get; set; }
        public List<Product> Products { get; set; }
    }
}
