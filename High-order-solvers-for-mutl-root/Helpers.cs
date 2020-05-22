using System;
using System.Collections.Generic;
using System.Text;

namespace High_order_solvers_for_mutl_root
{
    static class Helpers
    {
        public static void DisplayValue(double value, int countPlacecAfterComa)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var pattern = $"0.{new string('#', countPlacecAfterComa)}";
            Console.WriteLine(value.ToString(pattern));
            Console.ResetColor();
        }

        public static double Differences(
            Func<double, double> f,
            double x_prev,
            double x_n)
        {
            var num = f(x_n) - f(x_prev);
            var den = x_n - x_prev;
            return num / den;
        }

        public static double Difference_Sencond(
            Func<double, double> f,
            double x_prev_prev,
            double x_prev,
            double x)
        {
            var num = Differences(f, x, x_prev) - Differences(f, x_prev, x_prev_prev);

            var den = x - x_prev;

            return num / den;
        }
    }
}
