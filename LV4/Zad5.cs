using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    public class DiscountedItem: RentableDecorator
    {
        private readonly double DiscountPercentage;
        public DiscountedItem(IRentable rentable, double discountPercentage) : base(rentable)
        {
            this.DiscountPercentage = discountPercentage;
        }
        public override double CalculatePrice()
        {
            return base.CalculatePrice() * (1 - DiscountPercentage / 100);
        }
        public override String Description
        {
            get
            {
                return base.Description + $" now at {DiscountPercentage} % off!";
            }
        }
    }
}
