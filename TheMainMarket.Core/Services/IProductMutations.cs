using HotChocolate;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.General;
using TheMainMarket.DTOs.ProductDtos;

namespace TheMainMarketCore.Services
{
    public interface IProductMutations
    {
        Task<ProductPayload> AddProduct(AddProductInput input, [Service] AppDbContext context);
        Task<ProductPayload> DeleteProduct(DeleteInput input, [Service] AppDbContext context);
        Task<ProductPayload> UpdateProduct(UpdateProductInput input, [Service] AppDbContext context);
    }
}