
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WindowsResourcesCollector.Backend;

namespace WindowsResourcesCollector
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
	    public ObservableCollection<ImageTemplate> Images = new ObservableCollection<ImageTemplate>();
        public MainWindow()
        {
            Images.Add(new ImageTemplate(@"C:\Users\dylanedd\Pictures\ProofOf"));
            Images.Add(new ImageTemplate(@"C:\Users\dylanedd\Pictures\ProofOf"));
            Images.Add(new ImageTemplate(@"C:\Users\dylanedd\Pictures\ProofOf"));
            Images.Add(new ImageTemplate(@"C:\Users\dylanedd\Pictures\ProofOf"));

            InitializeComponent();

            ImageList.DataContext = Images;
            var bind = new Binding();
            ImageList.SetBinding(ItemsControl.ItemsSourceProperty, bind);

        }

    }
}