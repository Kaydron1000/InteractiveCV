using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace InteractiveCV.ViewModels
{
    public interface IOpenCVProperty
    {
        public string Name { get; set; }
    }
    public interface IOpenCVMinMaxProperty
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
    public interface IOpenCVColorProperty
    {
        public byte Color { get; set; }
    }
    public interface IOpenCVAnalogProperty
    {
        public float Value { get; set; }
    }
    public interface IOpenCVDiscreateProperty
    {
        public uint Value { get; set; }
    }
    public interface IOpenCVEnableProperty
    {
        public bool IsEnabled { get; set; }
    }
    public class OpenCVFunctionMinMaxProperty : INotifyPropertyChanged, IOpenCVProperty, IOpenCVEnableProperty, IOpenCVMinMaxProperty
    {
        private string _name;
        private bool _isEnabled;
        private double _minValue;
        private double _maxValue;

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetField(ref _isEnabled, value); }
        }
        public double MinValue
        {
            get { return _minValue; }
            set { SetField(ref _minValue, value); }
        }

        public double MaxValue
        {
            get { return _maxValue; }
            set { SetField(ref _maxValue, value); }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    public class OpenCVFunctionColorProperty : INotifyPropertyChanged, IOpenCVProperty, IOpenCVEnableProperty, IOpenCVColorProperty
    {
        private string _name;
        private bool _isEnabled;
        private byte _color;

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetField(ref _isEnabled, value); }
        }
        public byte Color
        {
            get { return _color; }
            set { SetField(ref _color, value); }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    public class OpenCVFunctionAnalogProperty : INotifyPropertyChanged, IOpenCVProperty, IOpenCVEnableProperty, IOpenCVAnalogProperty
    {
        private string _name;
        private bool _isEnabled;
        private float _value;

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetField(ref _isEnabled, value); }
        }
        public float Value
        {
            get { return _value; }
            set { SetField(ref _value, value); }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    public class OpenCVFunctionDiscreateProperty : INotifyPropertyChanged, IOpenCVProperty, IOpenCVEnableProperty, IOpenCVDiscreateProperty
    {
        private string _name;
        private bool _isEnabled;
        private uint _value;

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetField(ref _isEnabled, value); }
        }
        public uint Value
        {
            get { return _value; }
            set { SetField(ref _value, value); }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
    public class BlobDetectionViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<IOpenCVProperty> imageTranslationProperties;
        

        // Constructor
        public BlobDetectionViewModel()
        {
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
