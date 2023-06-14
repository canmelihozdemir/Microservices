using FreeCourse.Services.Basket.DTOs;
using FreeCourse.Shared.DTOs;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasketAsync(string userId);
        Task<Response<bool>> SaveOrUpdateAsync(BasketDto basketDto);
        Task<Response<bool>> DeleteAsync(string userId);
    }
}
