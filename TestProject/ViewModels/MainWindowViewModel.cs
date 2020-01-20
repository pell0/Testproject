using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TestProject.Command;
using TestProject.Common;
using TestProject.DataAccess;

namespace TestProject.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private readonly IUnitOfWork _uow;

        public MainWindowViewModel(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            AddPersonCommand = new RelayCommand(AddPerson);
            RefreshPeople();
        }

        public string PersonName { get; set; }

        public ICommand AddPersonCommand { get; set; }

        public ObservableCollection<Person> People { get; set; }

        private void AddPerson()
        {
            _uow.PersonRepository.Insert(new Common.Person() {Name = PersonName });
            _uow.Save();

            RefreshPeople();
        }

        private void RefreshPeople()
        {
            People = new ObservableCollection<Person>(_uow.PersonRepository.Get());
            OnPropertyChanged(nameof(People));
        }
    }
}
