using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WindowsResourcesCollector.Backend;

using Orientation = WindowsResourcesCollector.Backend.Orientation;

namespace WindowsResourcesCollector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public List<ResourceHandler> Images;
        public MainWindow()
        {
            var path = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile) +
                                                 @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\";
            InitializeComponent();
            Images = ImageHandler.RetrieveImages(path);
            ImageList.DataContext = Images;
            var bind = new Binding();
            ImageList.SetBinding(ItemsControl.ItemsSourceProperty, bind);
            CountLabel.Content = Images?.Count;
            
        }

        private void FilterBy_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = (FilterBy.SelectedIndex);
            Orientation filter = Orientation.Portrait;
            switch (i)
            {
                case 1:
                    filter = Orientation.Portrait;
                    break;
                case 2:
                    filter = Orientation.Landscape;
                    break;
                case 3:
                    filter = Orientation.Square;
                    break;
                default:
                    i = 0;
                    break;
            }

            ImageList.DataContext = i > 0 ? Images.Where(val => val.ImageOrientation == filter) : Images;
                var bind = new Binding();
                ImageList.SetBinding(ItemsControl.ItemsSourceProperty, bind);
                CountLabel.Content = i > 0 ? Images?.Count(val => val.ImageOrientation == filter) : Images?.Count;
            Console.WriteLine(i);

        }

        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var viewer = (ScrollViewer)sender;
            viewer.ScrollToVerticalOffset(viewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
