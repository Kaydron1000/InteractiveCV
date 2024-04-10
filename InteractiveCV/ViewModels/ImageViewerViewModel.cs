using InteractiveCV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace InteractiveCV.ViewModels
{
    public class ImageViewerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ImageManager _imageManger;
        private MyModel _myModel;
        
        public ImageViewerViewModel()
        {

            Model = (MyModel)App.Current.MainWindow.DataContext;
        }

        public MyModel Model
        {
            get { return _myModel; }
            set { SetField(ref _myModel, value); }
        }
        public ImageManager ImageSource
        {
            get 
            {
                if (_myModel.OrderedImgs != null && _myModel.OrderedImgs.Count >0)
                {
                    return _myModel.OrderedImgs.Last();
                }
                return null;
            }
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
}
