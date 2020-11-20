using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace DnDHelper
{
    public static class Declarations
    {
        public static int Roll(Random rnd, int m, int s, int a)
        {
            int result = 0;

            for (int i = 0; i < m; i++)
            {
                int add = rnd.Next(s) + 1;
                result += add;
            }

            result += a;

            return result;
        }

        public static void RollToText(Random rnd, TextBlock tB, Border border, uint m, int s, int a)
        {
            int result = 0;

            for (int i = 0; i < m; i++)
            {
                int add = rnd.Next(s) + 1;
                result += add;

                var lgb = new LinearGradientBrush()
                {
                    StartPoint = new System.Windows.Point(0, 1),
                    EndPoint = new System.Windows.Point(0, 0)
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

                border.Background = lgb;
            }

            result += a;

            tB.Text = result.ToString();
        }
    }
}
