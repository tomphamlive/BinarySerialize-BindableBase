using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using PeopleLibrary.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (DataContext is MainWindowViewModel vm)
                vm.StudentsItemsControlViewModel = StudentsItemsControl.DataContext as StudentsItemsControlViewModel;
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            var regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            var isMatch = regex.IsMatch(text);

            return !isMatch;
        }
    }
}
