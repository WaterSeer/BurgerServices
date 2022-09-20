using Doscount.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doscount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);

    }
}
