using GrantAdvance.Domain.Models;

namespace GrantAdvance.Domain.ViewModel
{
    public class ProductResponseViewModel : BaseResponse
    {
        public Product? Product { get; private set; }

        public ProductResponseViewModel(bool success, string? message, Product? product) : base(success, message)
        {
            Product = product;
        }
    }
}
