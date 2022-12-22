using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    public class SchedulePageViewModel : ViewModelBasePage, IAsyncInitialization
    {
        private readonly IResidenceService residenceService;
        private string month;

        public SchedulePageViewModel(IResidenceService residenceService)
            : base(PageType.Schedule)
        {
            Month = DateTime.Now.ToString("MMMM yyyy");

            CreateMonth(DateTime.Now.Year, DateTime.Now.Month);
            this.residenceService = residenceService;
            Initialization = LoadPesidence();
        }

        public ObservableCollection<Day> Days { get; private set; }
                = new ObservableCollection<Day>();
        public ObservableCollection<ResidenceModel> Residences { get; private set; }
                = new ObservableCollection<ResidenceModel>();

        public string Month
        {
            get { return month; }
            set
            {
                SetProprty(ref month, value);
            }
        }

        public Task Initialization { get; }

        private async Task LoadPesidence()
        {
            try
            {
                var list = await residenceService.GetAllAsync();
                Residences.Clear();
                foreach (var item in list)
                {
                    Residences.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CreateMonth(int year, int month)
        {
            var countdays = DateTime.DaysInMonth(year, month);
            var week = 0;
            for (int i = 1; i <= countdays; i++)
            {
                var day = new DateTime(year, month, i);

                var dayOfWeek = (int)day.DayOfWeek;

                Days.Add(new Day
                {
                    WeekNo = week,
                    Date = day,
                    DayOfWeek = (dayOfWeek == 0 ? 7 : dayOfWeek) - 1,
                    Content = "Saint Germain dés Près",
                    NumberOfDay = i,
                    HoursAm = "4h",
                    HoursPm = "4h"
                });

                if (dayOfWeek == 0)
                    week++;
            }

            Days[9].Content = string.Empty;
            Days[6].Content = string.Empty;
            Days[15].Content = string.Empty;
            Days[16].Content = string.Empty;
            Days[22].Content = string.Empty;
            Days[11].Content = string.Empty;
            Days[12].Content = string.Empty;
        }
    }

}
