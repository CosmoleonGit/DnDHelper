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
    /// Interaction logic for CommonControl.xaml
    /// </summary>
    public partial class CommonControl : UserControl
    {
        public CommonControl()
        {
            InitializeComponent();
        }

        readonly Random rnd = new Random();

        private void AbilityCheck(int value)
        {
            //ResultTxt.Text = (rnd.Next(20) + value + 1).ToString();
            ResultTxt.Text = Declarations.Roll(rnd, 1, 20, value).ToString();
        }

        private void InitiativeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            InitiativeBtn.IsEnabled = int.TryParse(InitiativeTxt.Text, out int _);
        }

        private void StrengthTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StrengthBtn.IsEnabled = int.TryParse(StrengthTxt.Text, out int _);
        }

        private void DexterityTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            DexterityBtn.IsEnabled = int.TryParse(DexterityTxt.Text, out int _);
        }

        private void ConsitutionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConsitutionBtn.IsEnabled = int.TryParse(ConsitutionTxt.Text, out int _);
        }

        private void IntelligenceTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            IntelligenceBtn.IsEnabled = int.TryParse(IntelligenceTxt.Text, out int _);
        }

        private void WisdomTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            WisdomBtn.IsEnabled = int.TryParse(WisdomTxt.Text, out int _);
        }

        private void CharismaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharismaBtn.IsEnabled = int.TryParse(CharismaTxt.Text, out int _);
        }

        private void InitiativeBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(InitiativeTxt.Text));
        }

        private void StrengthBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(StrengthTxt.Text));
        }

        private void DexterityBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(DexterityTxt.Text));
        }

        private void ConsitutionBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(ConsitutionTxt.Text));
        }

        private void IntelligenceBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(IntelligenceTxt.Text));
        }

        private void WisdomBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(WisdomTxt.Text));
        }

        private void CharismaBtn_Click(object sender, RoutedEventArgs e)
        {
            AbilityCheck(int.Parse(CharismaTxt.Text));
        }
    }
}
