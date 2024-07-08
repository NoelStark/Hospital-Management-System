using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.ViewModels
{
    public class PrivacyPolicyViewModel : INotifyPropertyChanged
    {
        private bool _privacypolicyChecked, _shareinfoChecked;

        public bool PrivacyPolicyChecked
        {
            get { return _privacypolicyChecked; }
            set
            {
                _privacypolicyChecked = value;
                OnPropertyChanged(nameof(PrivacyPolicyChecked));
            }
        }

        public bool ShareInfoChecked
        {
            get { return _shareinfoChecked; }
            set { _shareinfoChecked = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
