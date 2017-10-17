using CommonLibrary.MVVM;
using PeopleLibrary.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeopleLibrary.ViewModels
{
    [Serializable]
    public class StudentsItemsControlViewModel : SerializableBindableBase
    {
        #region Constructor

        public StudentsItemsControlViewModel()
        {
            _students = new ObservableCollection<StudentViewModel>();
        }

        #endregion

        #region Properties

        private ObservableCollection<StudentViewModel> _students;
        public ObservableCollection<StudentViewModel> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }

        private StudentViewModel _selectedStudent;
        public StudentViewModel SelectedStudent
        {
            get => _selectedStudent;
            set => SetProperty(ref _selectedStudent, value);
        }

        #endregion

        #region Public Methods

        public void AddMaleStudent()
        {
            var svm = new StudentViewModel
            {
                Parent = this,
                Student = new MaleStudent(),
                StudentImageUrl = MaleStudent.ImagePath
            };
            Students.Add(svm);
        }

        public void AddFemaleStudent()
        {
            var svm = new StudentViewModel
            {
                Parent = this,
                Student = new FemaleStudent(),
                StudentImageUrl = FemaleStudent.ImagePath
            };
            Students.Add(svm);
        }

        public void ReInitializeProperties(StudentsItemsControlViewModel viewModel)
        {
            Students = viewModel.Students;
            SelectedStudent = viewModel.SelectedStudent;

            ReInitializeStaticFields();
        }

        private void ReInitializeStaticFields()
        {
            var lastMale = Students.LastOrDefault(s => s.Student is MaleStudent);
            if (lastMale != null)
                MaleStudent.MaleIdCount = lastMale.Student.Id;

            var lastFemale = Students.LastOrDefault(s => s.Student is FemaleStudent);
            if (lastFemale != null)
                FemaleStudent.FemaleIdCount = lastFemale.Student.Id;
        }

        #endregion
    }
}
