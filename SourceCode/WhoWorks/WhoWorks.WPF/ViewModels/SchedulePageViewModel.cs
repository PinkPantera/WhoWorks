using ClientDataService.Interfaces;
using ClientDataService.Models;
using ClientDataService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;
using WhoWorks.WpfCustomControlLibrary.CustomControls;

namespace WhoWorks.WPF.ViewModels
{
    public class SchedulePageViewModel : ViewModelBasePage, IAsyncInitialization
    {
        private readonly IResidenceService residenceService;
        private readonly IScheduleService scheduleSevice;
        private string month;
        private ResidenceModel currentResidance;

        public SchedulePageViewModel(IResidenceService residenceService, IScheduleService scheduleSevice)
            : base(PageType.Schedule)
        {
            Month = DateTime.Now.ToString("MMMM yyyy");

            this.residenceService = residenceService;
            this.scheduleSevice = scheduleSevice;
            Initialization = LoadPesidence();
            ResidanceChanged = new RalayCommand<object>(ResidanceChangedExecute);
        }


        public ObservableCollection<Day> Days { get; private set; }
                = new ObservableCollection<Day>();
        public ObservableCollection<ResidenceModel> Residences { get; private set; }
                = new ObservableCollection<ResidenceModel>();

        public ICommand ResidanceChanged { get; set; }
        public ResidenceModel CurrentResidance
        {
            get
            {
                return currentResidance;
            }
            set
            {
                SetProprty(ref currentResidance, value);
            }
        }

        public string Month
        {
            get { return month; }
            set
            {
                SetProprty(ref month, value);
            }
        }

        public Task Initialization { get; }

        private void ResidanceChangedExecute(object obj)
        {
            if (CurrentResidance != null)
                CreateMonth(DateTime.Now.Year, DateTime.Now.Month, CurrentResidance);
        }

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

                CurrentResidance = Residences.FirstOrDefault();

                ResidanceChangedExecute(0);
            }
            catch (Exception ex)
            {

            }
        }
        private async void CreateMonth(int year, int month, ResidenceModel residenceModel)
        {
            var list = await scheduleSevice.GetSchedulesResidanceByMonthAsync(year, month, residenceModel.Id);

            var countdays = DateTime.DaysInMonth(year, month);

            var week = 0;
            for (int i = 1; i <= countdays; i++)
            {
                var day = new DateOnly(year, month, i);

                var dayOfWeek = (int)day.DayOfWeek;
                //var tmp = list.Where(item => item.Date == day)
                //     .Select(s =>
                //        $"{s.Person.FirstName} {s.Person.SecondName}: {s.TimeBegin.ToString("HH.mm")} - {s.TimeEnd.ToString("HH.mm")}")
                //     .DefaultIfEmpty()
                //     .Aggregate((x, y) => x + "\n" + y);


                var listHours = list.Where(item => item.Date == day)
                                    .Select(s => new AssignedHours
                                    {
                                        Name = s.Person.FirstName,
                                        Duration = $" {s.TimeBegin.ToString("HH.mm")} - {s.TimeEnd.ToString("HH.mm")}",
                                        Id = s.Person.Id
                                    }).ToList();

                Days.Add(new Day
                {
                    WeekNo = week,
                    Date = day,
                    DayOfWeek = (dayOfWeek == 0 ? 7 : dayOfWeek) - 1,
                    Content = listHours.Count > 0 ? residenceModel.Name : default(string),
                    NumberOfDay = i,
                    Hours = listHours
                });

                if (dayOfWeek == 0)
                    week++;
            }

            //Days[9].Content = string.Empty;
            //Days[6].Content = string.Empty;
            //Days[15].Content = string.Empty;
            //Days[16].Content = string.Empty;
            //Days[22].Content = string.Empty;
            //Days[11].Content = string.Empty;
            //Days[12].Content = string.Empty;
        }
    }

}
