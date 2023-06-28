using Practice1.Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models
{
    internal class ParamsTable
    {
        public Rates UserRates { get; }
        public  UserMoney UserMoney { get; }
        public Wastes UserWastes { get; }

        public ParamsTable(Rates rates, UserMoney money, Wastes wastes)
        {
            UserRates = rates;
            UserMoney = money;
            UserWastes = wastes;
        }
    }
}
