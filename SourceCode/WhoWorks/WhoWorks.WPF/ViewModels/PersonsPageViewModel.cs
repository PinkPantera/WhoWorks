using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    public class PersonsPageViewModel : ViewModelBasePage, IPage, IAsyncInitialization
    {
        private readonly IPersonService personService;

        public PersonsPageViewModel(IPersonService personService)
           : base(PageType.Persons)
        {
            this.personService = personService;
            Initialization = LoadPersons();
        }

        public ObservableCollection<PersonModel> Persons { get; private set; } 
            = new ObservableCollection<PersonModel>();

        public Task Initialization { get; }

        private async Task LoadPersons()
        {
            var list = await personService.GetAllAsync();
            Persons.Clear();

            foreach (var item in list)
            {
                Persons.Add(item);
            }
        }
    }
}
