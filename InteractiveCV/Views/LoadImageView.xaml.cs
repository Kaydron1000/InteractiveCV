using InteractiveCV.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoadImageView.xaml
    /// </summary>
    public partial class LoadImageView : UserControl
    {
        public LoadImageView()
        {
            InitializeComponent();
        }

        private void Combobox_ImageReadMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext is LoadImageViewModel vm)
            {
                if (File.Exists(Textbox_ImageFilePath.Text))
                    vm.LoadImgCommand.Execute(Textbox_ImageFilePath.Text);
            }
        }
    }
}
