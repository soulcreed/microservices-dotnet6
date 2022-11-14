using AutoMapper;
using Shopp.CouponAPI.Data.ValueObjects;
using Shopp.CouponAPI.Model;

namespace Shopp.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
