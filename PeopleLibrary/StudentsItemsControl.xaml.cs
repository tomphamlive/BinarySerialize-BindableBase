using System.Windows.Controls;
using PeopleLibrary.ViewModels;

namespace PeopleLibrary
{
    public partial class StudentsItemsControl : UserControl
    {
        public StudentsItemsControl()
        {
            InitializeComponent();

            DataContext = new StudentsItemsControlViewModel();
        }
    }
}
