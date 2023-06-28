using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models.Params
{
    internal record Wastes
    {
        public decimal ApartamentCost { get; init; }
        public decimal RentalHousing { get; init; }
    }
}
