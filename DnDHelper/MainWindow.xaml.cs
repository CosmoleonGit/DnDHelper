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

namespace DnDHelper
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

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        readonly RollControl rc = new RollControl();
        readonly CommonControl cc = new CommonControl();
        readonly MacroControl mc = new MacroControl();

        private void RollSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            RightContent.Content = rc;
        }

        private void CommonSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            RightContent.Content = cc;
        }

        private void MacroSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            RightContent.Content = mc;
        }
    }
}
