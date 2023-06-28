using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models.Params
{
    internal record Rates
    {
        public int MortgageRate { get; init; }
        public int DepositRate { get; init; }
        public int Percent { get; set; }
    }
}
