using GroupingDataCollectionView.ViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GroupingDataCollectionView.Models
{
    public class EmployeeGroup : ObservableRangeCollection<EmployeeModel>,INotifyPropertyChanged
    {
        public string GroupTitle { get; set; }
        public string FooterTitle { get; set; }

        private string _groupIcon = "down_arrow";
        public string GroupIcon
        {
            get => _groupIcon;
            set=> SetProperty(ref _groupIcon,value);
        }

        public EmployeeGroup(string groupTitle, List<EmployeeModel> employees, string footerTitle = "") : base(employees)
        {
            GroupTitle = groupTitle;
            FooterTitle = footerTitle;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
      [CallerMemberName] string propertyName = "",
      Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class EmployeeModel
    {
        public string FullName { get; set; }
    }
}
