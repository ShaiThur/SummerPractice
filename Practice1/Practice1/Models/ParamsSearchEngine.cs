using Practice1.Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models
{
    internal class ParamsSearchEngine
    {
        private ParamsTable table;

        public ParamsSearchEngine(ParamsTable table)
        {
            this.table = table;
        }

        public IEnumerable<decimal> CreateChartData()
        {
            var chartData = new List<decimal>();
            var deposit = table.UserMoney.SavedMoney;
            int months = 0;

            while (deposit < table.UserWastes.ApartamentCost * (table.UserRates.Percent / 100m))
            {
                months++;
                deposit = deposit + deposit * table.UserRates.DepositRate / 100 / 12 + table.UserMoney.Salary - table.UserWastes.RentalHousing;
                chartData.Add(deposit);
            }

            var credit = table.UserWastes.ApartamentCost - deposit;
            deposit = 0;
            while (credit > 0)
            {
                months++;
                credit = credit + credit * table.UserRates.MortgageRate / 100 / 12 - table.UserMoney.Salary;
                chartData.Add(0);
            }

            deposit -= credit;
            while (months < 239)
            {
                deposit += table.UserMoney.Salary;
                chartData.Add(deposit);
                months++;
            }

            return chartData;
        }
    }
}
