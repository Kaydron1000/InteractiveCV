using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveCV.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Button_LoadImg_Click(object sender, RoutedEventArgs e)
        {
            // Set CVFunctionView to the user control view for loading image
            CVFunctionView.Content = new LoadImageView();
        }

        private void Button_ColorTranslation_Click(object sender, RoutedEventArgs e)
        {
            // Set CVFunctionView to the user control view for color translation
            //CVFunctionView.Content = new ColorTranslationView();
        }

        private void Button_Threshold_Click(object sender, RoutedEventArgs e)
        {
            // Set CVFunctionView to the user control view for threshold
            CVFunctionView.Content = new ThresholdPropertiesView();
        }

        private void Button_BlobDetection_Click(object sender, RoutedEventArgs e)
        {
            // Set CVFunctionView to the user control view for blob detection
            CVFunctionView.Content = new BlobDetectionView();
        }
    }
}
