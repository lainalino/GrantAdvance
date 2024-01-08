using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;

namespace GrantAdvance.Infras.Services.Interface
{
    public interface IProductService
    {
        Task<ProductResponseViewModel> CreateProductAsync(Product product);
        Task<ProductResponseViewModel?> FindByIdAsync(Guid id);
        Task<List<Product>> GetAll();
    }
}
