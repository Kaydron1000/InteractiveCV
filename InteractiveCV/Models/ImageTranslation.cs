using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractiveCV.Configuration;
using System.Xml.Serialization;
using OpenCvSharp;
using System.ComponentModel;

namespace InteractiveCV.Models
{
    public interface ICVFunction
    {
        public Mat InputMat { get; set; }
        public Mat OutputMat { get; set; }
        public string FunctionName { get; }
        
        public Mat ApplyFunction();    
    }
    public abstract class ABCCVFunction : ICVFunction, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        protected Mat _inputMat;
        [XmlIgnore]
        protected Mat _outputMat;

        [XmlIgnore]
        public string FunctionName => nameof(BlobDetectionType);
        [XmlIgnore]
        public Mat InputMat
        {
            get => _inputMat;
            set
            {
                if (_inputMat != value)
                {
                    _inputMat = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InputMat)));
                    OutputMat = ApplyFunction();
                }
            }
        }
        [XmlIgnore]
        public Mat OutputMat
        {
            get => _outputMat;
            set
            {
                if (_outputMat != value)
                {
                    _outputMat = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OutputMat)));
                }
            }
        }

        public abstract Mat ApplyFunction();
    }
}
