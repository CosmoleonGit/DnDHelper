using System;
using System.CodeDom.Compiler;
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
    /// Interaction logic for MacroControl.xaml
    /// </summary>
    public partial class MacroControl : UserControl
    {
        public MacroControl()
        {
            InitializeComponent();
        }

        readonly List<Macro> macros = new List<Macro>();

        Macro SelectMacro => macros[MacroList.SelectedIndex];

        bool GetMacro(out Macro? macro)
        {
            if (uint.TryParse(ModifierTxt.Text, out uint m) &&
                int.TryParse(SidesTxt.Text, out int s) &&
                int.TryParse(AddTxt.Text, out int a))
            {
                macro = new Macro(m, s, a);

                return true;
            } else
            {
                macro = null;
                return false;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            GetMacro(out Macro? macro);
            //var macro = GetMacro();
            macros.Add(macro.Value);

            MacroList.Items.Add(macro.ToString());

            RefreshAdd();
        }

        private void ReplaceBtn_Click(object sender, RoutedEventArgs e)
        {
            GetMacro(out Macro? macro);

            macros[MacroList.SelectedIndex] = macro.Value;

            MacroList.Items[MacroList.SelectedIndex] = macro.ToString();

            RefreshAdd();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            macros.RemoveAt(MacroList.SelectedIndex);
            MacroList.Items.RemoveAt(MacroList.SelectedIndex);
        }

        struct Macro
        {
            public Macro(uint _mult, int _sides, int _add)
            {
                modifier = _mult;
                sides = _sides;
                add = _add;
            }

            public readonly uint modifier;

            public readonly int sides,
                                add;

            public override string ToString() =>
                $"{modifier}d{sides}" + (sides >= 0 ? "+" : "") + add.ToString();

            static readonly Random rnd = new Random();

            public void Roll(TextBlock txt, Border border)
            {
                Declarations.RollToText(rnd, txt, border, modifier, sides, add);
            }
        }

        private void MacroList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            

            ReplaceBtn.IsEnabled = MacroList.SelectedIndex != -1;
            RemoveBtn.IsEnabled = MacroList.SelectedIndex != -1;
            RollBtn.IsEnabled = MacroList.SelectedIndex != -1;

            if (MacroList.SelectedIndex != -1)
            {
                var macro = SelectMacro;

                ModifierTxt.Text = macro.modifier.ToString();
                SidesTxt.Text = macro.sides.ToString();
                AddTxt.Text = macro.add.ToString();
            }
        }

        private void RollBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectMacro.Roll(ResultTxt, ResultBorder);
        }

        private void ModifierTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshAdd();
        }

        private void SidesTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshAdd();
        }

        private void AddTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshAdd();
        }

        void RefreshAdd()
        {
            if (GetMacro(out Macro? temp))
            {
                AddBtn.IsEnabled = !macros.Contains(temp.Value);
            }
            else
            {
                AddBtn.IsEnabled = false;
            }
        }
    }
}
