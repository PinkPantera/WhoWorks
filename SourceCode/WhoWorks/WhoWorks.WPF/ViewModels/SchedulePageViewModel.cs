using ClientDataService.Interfaces;
using ClientDataService.Models;
using ClientDataService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
    public class SchedulePageViewModel : ViewModelBasePage, IInitialization
    {
        private readonly IResidenceService residenceService;
        private readonly IScheduleService scheduleSevice;
        private readonly IDialogService dialogService;
        private string month;
        private ResidenceModel currentResidance;


        public SchedulePageViewModel(IResidenceService residenceService, 
            IScheduleService scheduleSevice, IDialogService dialogService)
            : base(PageType.Schedule)
        {
            Month = DateTime.Now.ToString("MMMM yyyy");

            this.residenceService = residenceService;
            this.scheduleSevice = scheduleSevice;
            this.dialogService = dialogService;
            InitializationAsync = LoadPesidence();
            ResidanceChanged = new RalayCommand<object>(ResidanceChangedExecute);
            EditDayCommand = new RalayCommand<object>(EditDayCommandExecute);
        }

        public ObservableCollection<Day> Days { get; private set; }
                = new ObservableCollection<Day>();
        public ObservableCollection<ResidenceModel> Residences { get; private set; }
                = new ObservableCollection<ResidenceModel>();

        public ICommand ResidanceChanged { get; set; }
        public ICommand EditDayCommand { get; set; }
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

        public Task InitializationAsync { get; }

        #region Commands
        private void ResidanceChangedExecute(object obj)
        {
            if (CurrentResidance != null)
                CreateMonth(DateTime.Now.Year, DateTime.Now.Month, CurrentResidance);
        }
        private void EditDayCommandExecute(object obj)
        {
            var day = (Day)obj;
            if (day == null)
                return;
            if (day.State == StateOfDay.NotActive)
            {
                ActivateDay(day);
            }
           var result =  dialogService.ShowDialog<EditDayViewModel>(day);
        }

        private void ActivateDay(Day day)
        {
            Day? dayToActivate = Days.FirstOrDefault(item => item.Date == day.Date);

            if (dayToActivate != null)
            {
                dayToActivate.Content = currentResidance.Name;
                dayToActivate.IdContent = currentResidance.Id;
            }
        }

        #endregion
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

                var dayOfCalendar = new Day 
                { 
                    Date = day, 
                    DayOfWeek = (dayOfWeek == 0 ? 7 : dayOfWeek) - 1, 
                    NumberOfDay = i,
                    WeekNo = week
                };

                var assignedDay = list.Where(item => item.Date == day);
                List<AssignedHours> assignedHours;

                if (assignedDay != null && assignedDay.Any())
                {

                    assignedHours = list.Where(item => item.Date == day && item.Person != null)
                                    .Select(s => new AssignedHours
                                    {
                                        Name = s.Person.FirstName,
                                        Duration = $" {s.TimeBegin.ToString("HH.mm")} - {s.TimeEnd.ToString("HH.mm")}",
                                        Id = s.Person.Id
                                    }).ToList();

                    dayOfCalendar.IdContent = residenceModel.Id;
                    dayOfCalendar.Content = residenceModel.Name;
                    dayOfCalendar.Hours = assignedHours;
                }

                Days.Add(dayOfCalendar);

                if (dayOfWeek == 0)
                    week++;
            }
        }
    }

}
