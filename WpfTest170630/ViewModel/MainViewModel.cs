using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Microsoft.Expression.Interactivity.Core;
using WpfTest170630.Model;

namespace WpfTest170630.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private int _count;
        private ObservableCollection<string> _listSource;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                    }
                });
            ListSource = new ObservableCollection<string>
            {
                "test1",
                "qwerty",
                "MieHaHa"
            };
            NewWindow = new ActionCommand(() =>
            {
                Count++;
                new MainWindow().Show();
            });
        }

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public ObservableCollection<string> ListSource
        {
            get => _listSource;
            set => Set(ref _listSource, value);
        }

        public ICommand NewWindow { get; set; }
    }
}