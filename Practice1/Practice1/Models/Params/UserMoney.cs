using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models.Params
{
    internal record UserMoney
    {
        public decimal Salary { get; init; }
        public decimal SavedMoney { get; init; }
    }
}
