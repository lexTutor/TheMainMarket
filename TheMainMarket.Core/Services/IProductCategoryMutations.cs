using HotChocolate;
using System.Threading.Tasks;
using TheMainMarket.DataAccess;
using TheMainMarket.DTOs.CategoryDtos;
using TheMainMarket.DTOs.General;

namespace TheMainMarketCore.Services
{
    public interface IProductCategoryMutations
    {
        Task<CategoryPayload> AddCategory(AddCategoryInput input, [Service] AppDbContext context);
        Task<CategoryPayload> DeleteCategory(DeleteInput input, [Service] AppDbContext context);
        Task<CategoryPayload> UpdateCategory(UpdateCategoryInput input, [Service] AppDbContext context);
    }
}