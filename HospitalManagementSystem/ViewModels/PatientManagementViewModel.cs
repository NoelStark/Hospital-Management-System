using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HospitalManagementSystem.Commands;

namespace HospitalManagementSystem.ViewModels
{
    public class PatientManagementViewModel
    {
        public ICommand OnNewPatientCommand { get; set; }
        private MainViewModel _mainViewModel;

        public PatientManagementViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            OnNewPatientCommand = new RelayCommand(NewPatient);
        }

        private void NewPatient(object x)
        {
            _mainViewModel.CurrentViewKey = "PersonalInformationTemplate";
        }
    }
}
