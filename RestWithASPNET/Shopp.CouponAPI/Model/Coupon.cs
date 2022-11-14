using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shopp.CouponAPI.Model.Base;

namespace Shopp.CouponAPI.Model
{
    public class Coupon : BaseEntity
    {
        [Column("coupon_code")]
        [Required]
        [StringLength(30)]
        public string CouponCode { get; set; }

        [Column("discount_amount")]
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}
