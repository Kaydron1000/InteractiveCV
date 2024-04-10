using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using Microsoft.Extensions.DependencyInjection;

namespace InteractiveCV.Models
{
    public class NewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ICVFunction> _orderedImgs;

        public ObservableCollection<ICVFunction> OrderedImgs
        {
            get => _orderedImgs;
            set => SetField(ref _orderedImgs, value);
        }


        public NewModel()
        {
            OrderedImgs = new ObservableCollection<ICVFunction>();
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
    //public class ImageManager : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private BitmapSource _image;
    //    private Mat _cvImage;

    //    public BitmapSource Image
    //    {             
    //        get { return _image; }
    //        set 
    //        { 
    //            _image = value;
    //            _cvImage = _image.ToMat();
    //            OnPropertyChanged(nameof(Image));
    //            OnPropertyChanged(nameof(CvImage));
    //        }
    //    }
    //    public Mat CvImage
    //    {
    //        get { return _cvImage; }
    //        set 
    //        { 
    //            _cvImage = value;
    //            _image = _cvImage.ToBitmapSource();
    //            OnPropertyChanged(nameof(Image));
    //            OnPropertyChanged(nameof(CvImage));
    //        }
    //    }

    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //}
}
