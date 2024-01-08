
using GrantAdvance.Domain.Models;

namespace GrantAdvance.Infras.Repositories.Interface
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product?> FindByIdAsync(Guid id);
        Task<List<Product>> GetAll();
    }
}
