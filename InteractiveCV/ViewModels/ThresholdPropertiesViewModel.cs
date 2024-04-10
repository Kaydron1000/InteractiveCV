using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenCvSharp;

namespace InteractiveCV.ViewModels
{
    public class ThresholdPropertiesViewModel : INotifyPropertyChanged
    {
        private bool _grayScaleImage;
        private int _thresholdMinValue;
        private int _thresholdMaxValue;
        private ThresholdTypes _thresholdType;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool GrayScaleImage
        {
            get { return _grayScaleImage; }
            set { SetField(ref _grayScaleImage, value); }
        }

        public int ThresholdMinValue
        {
            get { return _thresholdMinValue; }
            set { SetField(ref _thresholdMinValue, value); }
        }

        public int ThresholdMaxValue
        {
            get { return _thresholdMaxValue; }
            set { SetField(ref _thresholdMaxValue, value); }
        }

        public ThresholdTypes ThresholdType
        {
            get { return _thresholdType; }
            set { SetField(ref _thresholdType, value); }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
