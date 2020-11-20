using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for RollControl.xaml
    /// </summary>
    public partial class RollControl : UserControl
    {
        public RollControl()
        {
            InitializeComponent();
        }

        readonly Random rnd = new Random();

        private void RollBtn_Click(object sender, RoutedEventArgs e)
        {
            uint m = uint.Parse(ModifierTxt.Text);
            int s = int.Parse(SidesTxt.Text);
            int a = int.Parse(AddTxt.Text);

            Declarations.RollToText(rnd, ResultTxt, ResultsLbl, m, s, a);

            /*
            int result = 0;

            for (int i = 0; i < m; i++)
            {
                int add = rnd.Next(s) + 1;
                result += add;

                var lgb = new LinearGradientBrush()
                {
                    StartPoint = new Point(0, 1),
                    EndPoint = new Point(0, 0)
                };

                GradientStop gs1, gs2;

                if (add == 1)
                {
                    gs1 = new GradientStop() { Color = Colors.Red, Offset = 0 };
                    gs2 = new GradientStop() { Color = Colors.DarkRed, Offset = 1 };
                }
                else if (add == s)
                {
                    gs1 = new GradientStop() { Color = Colors.Lime, Offset = 0 };
                    gs2 = new GradientStop() { Color = Colors.Green, Offset = 1 };
                }
                else
                {
                    gs1 = new GradientStop() { Color = Colors.LightGray, Offset = 0 };
                    gs2 = new GradientStop() { Color = Colors.DarkGray, Offset = 1 };
                }

                lgb.GradientStops = new GradientStopCollection { gs1, gs2 };

                ResultsLbl.Background = lgb;
            }

            result += a;

            ResultTxt.Text = result.ToString();
            */
        }

        private void ModifierTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOK();
        }

        private void SidesTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOK();
        }

        private void AddTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOK();
        }

        private void UpdateOK()
        {
            RollBtn.IsEnabled = int.TryParse(ModifierTxt.Text, out int m) && m > 0 &&
                                int.TryParse(SidesTxt.Text, out int s) && s > 0 &&
                                int.TryParse(AddTxt.Text, out int _);
        }
    }
}
