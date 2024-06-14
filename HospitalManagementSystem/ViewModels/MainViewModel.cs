using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HospitalManagementSystem.Commands;

namespace HospitalManagementSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string currentViewKey;
        public string CurrentViewKey
        {
            get => currentViewKey;
            set
            {
                currentViewKey = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnClickCommand { get; set; }

        public MainViewModel()
        {
            OnClickCommand = new RelayCommand(SwitchView);
            CurrentViewKey = "PersonalInformation";
        }

        private void SwitchView(object x)
        {
            CurrentViewKey = CurrentViewKey == "PersonalInformation" ? "Address" : "PersonalInformation";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}