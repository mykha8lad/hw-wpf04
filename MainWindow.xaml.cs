using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Globalization;
using System.Linq;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Colors
    {
        public int Alpha { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private Colors color;
        public MainViewModel()
        {
            color = new();
        }

        public int Alpha { get => color.Alpha; set { color.Alpha = value; UpdateColor(); } }
        public int Red { get => color.Red; set { color.Red = value; UpdateColor(); } }
        public int Green { get => color.Green; set { color.Green = value; UpdateColor(); } }
        public int Blue { get => color.Blue; set { color.Blue = value; UpdateColor(); } }
        private System.Windows.Media.Color backgroundColor;
        public System.Windows.Media.Color BackgroundColor { get => backgroundColor; set { backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); } }

        private void UpdateColor()
        {
            BackgroundColor = System.Windows.Media.Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
