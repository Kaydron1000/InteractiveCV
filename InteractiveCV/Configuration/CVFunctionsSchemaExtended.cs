using InteractiveCV.Models;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InteractiveCV.Configuration
{
    public partial class BlobDetectionType : ABCCVFunction
    {
        public override Mat ApplyFunction()
        {
            throw new NotImplementedException();
        }
    }
    public partial class LoadImageType : ABCCVFunction
    {
        public ImreadModes CvImreadMode 
        { 
            get
            {
                return (ImreadModes)Enum.Parse(typeof(ImreadModes), this.ImreadMode.ToString());
            } 
            set
            {
                this.ImreadMode = (Enum_ImreadModes)Enum.Parse(typeof(Enum_ImreadModes), value.ToString());
            }
        }
        public override Mat ApplyFunction()
        {
            throw new NotImplementedException();
        }
    }
}
