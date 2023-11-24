using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLib
{
    internal class DBvalidator
    {

        public static bool PriceValidator(int price) { return !(price < 0); }
        public static bool PriceValidator(decimal price) {  return !(price < 0); }
        public static bool PriceValidator(float price) { return !(price < 0); }
    }
}
