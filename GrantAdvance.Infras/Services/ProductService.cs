using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;
using GrantAdvance.Infras.Repositories.Interface;
using GrantAdvance.Infras.Services.Interface;

namespace GrantAdvance.Infras.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
          IProductRepository productRepository,
          IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary> 
        /// The method creates Product
        /// </summary>
        public async Task<ProductResponseViewModel> CreateProductAsync(Product product)
        {
            product.DateCreate = DateTime.Now;
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return new ProductResponseViewModel(true, null, product);
        }

        /// <summary> 
        /// The method get the information by Id
        /// </summary>
        public async Task<ProductResponseViewModel?> FindByIdAsync(Guid id)
        {
            var product = await _productRepository.FindByIdAsync(id);

            return new ProductResponseViewModel(true, null, product);
        }

        /// <summary> 
        /// The method get the all products
        /// </summary>
        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
    }
}
