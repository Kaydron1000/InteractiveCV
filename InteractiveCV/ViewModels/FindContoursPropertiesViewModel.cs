using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InteractiveCV.ViewModels
{
    internal class ContourItem
    {
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public Geometry Data { get; set; }
        public Brush ActiveStroke { get; set; }
        public Brush SelectedStroke { get; set; }
        public double ActiveStrokeThickness { get; set; }
        public double SelectedStrokeThickness { get; set; }

    }
    internal class FindContoursPropertiesViewModel
    {
        BinaryTree<ContourItem> _contoursTree;

        public FindContoursPropertiesViewModel()
        {
            _contoursTree = new BinaryTree<ContourItem>();
            _contoursTree.AddRoot(new ContourItem());
            _contoursTree.AddChild(_contoursTree.Root, new ContourItem());
        }
    }
}
