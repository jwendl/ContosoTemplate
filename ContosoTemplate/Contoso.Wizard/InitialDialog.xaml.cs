using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Contoso.Wizard
{
    /// <summary>
    /// Interaction logic for InitialDialog.xaml
    /// </summary>
    public partial class InitialDialog 
        : Window, INotifyPropertyChanged
    {
        public string SelectedCulture { get; set; }

        public ObservableCollection<LanguageModel> LanguageValues { get; private set; }

        public InitialDialog()
        {
            DataContext = this;

            InitializeComponent();
            InitializeCultures();
        }

        private void InitializeCultures()
        {
            LanguageValues = new ObservableCollection<LanguageModel>()
            {
                new LanguageModel() { Text = "English US", Value = "en-US" },
                new LanguageModel() { Text = "English UK", Value = "en-UK" },
                new LanguageModel() { Text = "Italian", Value = "it-IT" },
                new LanguageModel() { Text = "French", Value = "fr-FR" },
            };

            OnPropertyChanged("LanguageValues");
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            SelectedCulture = null;
            Close();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
