using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopp.CouponAPI.Data.ValueObjects;
using Shopp.CouponAPI.Model.Context;

namespace Shopp.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CouponRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}