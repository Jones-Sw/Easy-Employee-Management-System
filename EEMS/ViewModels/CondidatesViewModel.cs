using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.UI.Views.Employees;
using System.Windows;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess.Models;

namespace EEMS.UI.ViewModels
{
    public partial class CondidatesViewModel : ObservableObject
    {

        private readonly ICondidateManagementService _condidateManagementService;
        public ObservableCollection<DataAccess.Models.Condidate> Condidates { get; set; }

        //[NotifyCanExecuteChangedFor(nameof(ViewEmployeeCommand))]
        [ObservableProperty]
        private DataAccess.Models.Condidate _selectedCondidate;

        [ObservableProperty]
        private bool _isEditing;

        [RelayCommand]
        private void AddCondidate()
        {
            MessageBox.Show("AddCondidateCommand triggered!");
            // Open your add window here
        }
        
        public CondidatesViewModel(ICondidateManagementService condidateManagementService)
        {
            if (condidateManagementService == null)
                throw new Exception("condidateManagementService is null!");
            _condidateManagementService = condidateManagementService;
            Condidates = new ObservableCollection<Condidate>();
            LoadCondidate();
        }

        [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
        private void ViewCondidate(object obj)
        {
            if (SelectedCondidate
                != null)
            {
                var employeeDetails = new ViewEmployeeDetailsViewModel(SelectedCondidate);
                var viewCondidateDetailsWindow = new ViewEmployeeDetails(employeeDetails);
                viewCondidateDetailsWindow.ShowDialog();
                SelectedCondidate = null;
            }
        }

        private bool CanPerformUserAction(object obj)
        {
            return SelectedCondidate != null && !IsEditing;
        }

        //partial void OnIsEditingChanged(bool value)
        //{
        //    OnPropertyChanged(nameof(IsNotEditing));
        //    ViewCondidateCommand.NotifyCanExecuteChanged();
        //}

        //partial void OnSelectedCondidateChanged(DataAccess.Models.Employee value)
        //{
        //    ViewCondidateCommand.NotifyCanExecuteChanged();
        //}


        //public CondidatesViewModel(ICondidateManagementService condidateManagementService)
        //{
        //    _condidateManagementService = condidateManagementService;
        //    Condidate = new ObservableCollection<DataAccess.Models.Condidate>();
        //    IsEditing = false;
        //    LoadCondidate();
        //}

        //[RelayCommand]
        //private void AddCondidate()
        //{
        //    var viewModel = new AddAndEditWindowViewModel(new PersonalInformationViewModel(),
        //    new JobInformationViewModel(_condidateManagementService),
        //                                                  _condidateManagementService);

        //    viewModel.UpdateGridWindowData = LoadCondidate;

        //    var AddAndEditWindow = new AddAndEditWindow(viewModel);
        //    AddAndEditWindow.ShowDialog();
        //}


        private async void LoadCondidate()
        {
            Condidates.Clear();

            //if (_condidateManagementService == null)
            //{
            //    MessageBox.Show("Error: condidateManagementService is null!");
            //    return;
            //}

            //if (_condidateManagementService.CondidatesService == null)
            //{
            //    MessageBox.Show("Error: CondidatesService is null!");
            //    return;
            //}

            var condidates = await _condidateManagementService.CondidatesService.GetAsync();
            foreach (var condidate in condidates)
            {
                Condidates.Add(condidate);
            }

        }
    }
}
