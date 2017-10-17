using CommonLibrary.MVVM;
using CommonLibrary.Serializers;
using PeopleLibrary.ViewModels;
using Prism.Commands;
using System;
using System.Windows.Input;

namespace WpfApp1
{
    [Serializable]
    public class MainWindowViewModel : SerializableBindableBase
    {
        #region Constructor

        public MainWindowViewModel()
        {
            FileName = "Untitled";

            AddMaleCommand = new DelegateCommand(AddMaleStudent);
            AddFemaleCommand = new DelegateCommand(AddFemaleStudent);
            SaveCommand = new DelegateCommand(Save);
            OpenCommand = new DelegateCommand(Open);
        }

        #endregion

        #region Properties

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        public StudentsItemsControlViewModel StudentsItemsControlViewModel { get; set; }

        #endregion

        #region Commands

        [field: NonSerialized]
        private ICommand _addMaleCommand;
        public ICommand AddMaleCommand
        {
            get => _addMaleCommand;
            set => _addMaleCommand = value;
        }

        [field: NonSerialized]
        private ICommand _addFemaleCommand;
        public ICommand AddFemaleCommand
        {
            get => _addFemaleCommand;
            set => _addFemaleCommand = value;
        }

        [field: NonSerialized]
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get => _saveCommand;
            set => _saveCommand = value;
        }

        [field: NonSerialized]
        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get => _openCommand;
            set => _openCommand = value;
        }

        #endregion

        #region Private Methods

        private void AddFemaleStudent()
        {
            StudentsItemsControlViewModel.AddFemaleStudent();
        }

        private void AddMaleStudent()
        {
            StudentsItemsControlViewModel.AddMaleStudent();
        }

        private void Save()
        {
            string initialFileName = FileName;
            var filePathName = BinaryFileSerializer.GetSaveFilePathName(initialFileName);
            if (filePathName == null)
                return;

            //serializing MainWindowViewModel
            FileName = filePathName;
            BinaryFileSerializer.SerializeToFile(filePathName, this);
        }

        private void Open()
        {
            var filePathName = BinaryFileSerializer.GetOpenFilePathName();
            if (filePathName == null)
                return;

            //deserializing MainWindowViewModel
            var result = BinaryFileSerializer.DeserializeFromFile(filePathName);
            if (result == null)
                return;

            ReInitializeProperties(result as MainWindowViewModel);
        }

        private void ReInitializeProperties(MainWindowViewModel viewModel)
        {
            FileName = viewModel.FileName;

            StudentsItemsControlViewModel.ReInitializeProperties(viewModel.StudentsItemsControlViewModel);

            //ReInitializeStaticFields();
        }

        #endregion
    }
}
