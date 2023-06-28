using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Practice1.Models;
using Practice1.Models.Params;
using Practice1.Resources;
using SkiaSharp;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace Practice1.ViewModels
{
    internal class MainWindowVM : BaseVM
    {
        #region properties
        private ISeries[] series;
        public ISeries[] Series { get => series; set => SetProperty(ref series, value); }
        public ICommand CreateGraphic { get; private set; }

        private decimal apCost;
        public decimal ApCost { get => apCost; set => SetProperty(ref apCost, value); }

        private int depRate;
        public int DepRate { get => depRate; set => SetProperty(ref depRate, value); }

        private int mortRate;
        public int MortRate { get => mortRate; set => SetProperty(ref mortRate, value); }

        private decimal salary;
        public decimal Salary { get => salary; set => SetProperty(ref salary, value); }

        private decimal rent;
        public decimal Rent { get => rent; set => SetProperty(ref rent, value); }

        private decimal saves;
        public decimal Saves { get => saves; set => SetProperty(ref saves, value); }
        #endregion


        public MainWindowVM()
        {
            CreateGraphic = new RelayCommand(PerformCreateGraphic);
        }

        private void PerformCreateGraphic(object commandParameter)
        {
            UserMoney money = new UserMoney { Salary = Salary, SavedMoney = Saves };
            Wastes wastes = new Wastes { ApartamentCost = ApCost, RentalHousing = Rent };
            Rates rates = new Rates { DepositRate = DepRate, MortgageRate = MortRate };
            string[] names = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };
            ISeries[] serData = new ISeries[11];

            for (int i = 0; i < 11; i++)
            {
                rates.Percent = i * 10;
                ParamsTable table = new ParamsTable(rates, money, wastes);
                ParamsSearchEngine engine = new ParamsSearchEngine(table);

                var data = engine.CreateChartData();
                serData[i] = new LineSeries<decimal>
                {
                    Values = data.ToArray(),
                    Name = names[i]
                };
            }
            Series = serData;
        }
    }
}
