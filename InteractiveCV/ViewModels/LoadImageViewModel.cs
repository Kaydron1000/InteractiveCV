using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using OpenCvSharp;
using InteractiveCV.Models;
using System.Collections.ObjectModel;
using OpenCvSharp.WpfExtensions;
using InteractiveCV.Configuration;


namespace InteractiveCV.ViewModels
{
    public class LoadImageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _imageFilePath;
        private ObservableCollection<string> _imageReadModes;
        private string _selectedImageReadMode;
        private NewModel _myModel;

        public ObservableCollection<string> ImageReadModes
        {
            get { return _imageReadModes; }
            set { SetField(ref _imageReadModes, value); }
        }
        public string ImageFilePath
        {
            get { return _imageFilePath; }
            set { SetField(ref _imageFilePath, value); }
        }


        public NewModel Model
        {
            get { return _myModel; }
            set { SetField(ref _myModel, value); }
        }
        public string SelectedImageReadMode
        {
            get { return _selectedImageReadMode; }
            set { SetField(ref _selectedImageReadMode, value); }
        }
        public ICommand BrowseCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand ConfirmCommand { get; private set; }
        public ICommand LoadImgCommand { get; private set; }

        public LoadImageViewModel()
        {
            Model = (NewModel)App.Current.MainWindow.DataContext;
            ImageReadModes = new ObservableCollection<string>(Enum.GetNames(typeof(ImreadModes)));
            BrowseCommand = new RelayCommand(Browse);
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm);
            LoadImgCommand = new RelayCommand(LoadImage);
            LoadImageType lo = new LoadImageType();
            Model.OrderedImgs.Add(lo);
        }

        private void Browse(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                ImageFilePath = openFileDialog.FileName;
                LoadImage(null);
            }
        }

        private void LoadImage(object parameter)
        {
            if (!string.IsNullOrEmpty(ImageFilePath))
            {
                try
                {
                    ImreadModes readmode = (ImreadModes)Enum.Parse(typeof(ImreadModes), SelectedImageReadMode, true);
                    _imageManger.CvImage = Cv2.ImRead(ImageFilePath, readmode);
                    Image = _imageManger.Image;
                }
                catch (Exception ex)
                {
                    // Handle image loading exception
                }
            }
        }

        private void Cancel(object parameter)
        {
            // Implement cancel logic
        }

        private void Confirm(object parameter)
        {
            // Implement confirm logic
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
