using GrantAdvance.Data.Context;
using GrantAdvance.Domain.Models;
using GrantAdvance.Infras.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GrantAdvance.Infras.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
           await _context.Product.AddAsync(product);
        }

        public async Task<Product?> FindByIdAsync(Guid id)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
