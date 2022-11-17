using Shopp.CarAPI.Data.ValueObjects;

namespace Shopp.CarAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string couponCode, string token);
    }
}
