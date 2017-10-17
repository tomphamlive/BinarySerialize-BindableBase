using System.Windows;
using System.Windows.Controls;
using PeopleLibrary.Models;

namespace PeopleLibrary
{
    public class StudentsDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (!(item is Student))
                return null;

            if (!(container is FrameworkElement element))
                return null;

            return element.FindResource("StudentDataTemplate") as DataTemplate;


            //if (student is MaleStudent)
            //    return element.FindResource("MaleDataTemplate") as DataTemplate;

            //if (student is FemaleStudent)
            //    return element.FindResource("FemaleDataTemplate") as DataTemplate;

            //return null;
        }
    }
}
