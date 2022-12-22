using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    public class PersonsPageViewModel : ViewModelBasePage, IAsyncInitialization
    {
        private readonly IPersonService personService;
        private string errorInformation;

        public PersonsPageViewModel(IPersonService personService)
           : base(PageType.Persons)
        {
            this.personService = personService;
            Initialization = LoadPersons();
        }

        public ObservableCollection<PersonModel> Persons { get; private set; } 
            = new ObservableCollection<PersonModel>();


        public Task Initialization { get; }
        public string ErrorInformation
        {
            get => errorInformation; 
            set
            {
                SetProprty(ref errorInformation, value);
            }
        }

        private async Task LoadPersons()
        {
            ErrorInformation = string.Empty;
            IList<PersonModel> persons;
            try
            {
                persons = await personService.GetAllAsync();

                Persons.Clear();

                foreach (var item in persons)
                {
                    Persons.Add(item);
                }
            }
            catch(Exception ex)
            {
                ErrorInformation = ex.Message;
            }

        }
    }
}
