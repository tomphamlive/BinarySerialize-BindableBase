using CommonLibrary.MVVM;
using PeopleLibrary.Models;
using System;

namespace PeopleLibrary.ViewModels
{
    [Serializable]
    public class StudentViewModel : SerializableBindableBase
    {
        #region Properties

        public StudentsItemsControlViewModel Parent { get; set; }

        private Student _student;
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }

        private string _studentImageUrl;
        public string StudentImageUrl
        {
            get => _studentImageUrl;
            set => SetProperty(ref _studentImageUrl, "pack://application:,,,/PeopleLibrary;component/" + value);
        }

        #endregion
    }
}
