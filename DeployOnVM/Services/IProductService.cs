using DeployOnVM.Models;

namespace DeployOnVM.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBeta();
    }
}