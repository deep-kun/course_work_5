using System;
using System.Collections.Generic;
using System.Text;
using static High_order_solvers_for_mutl_root.Helpers;
using static System.Math;

namespace High_order_solvers_for_mutl_root.Methods
{
    class KingsFifth_orderMethod_3
    {
        private readonly double multiplicity;
        private readonly double initValue;
        private readonly double precision;

        public Func<double, double> Function { get; set; }
        public Func<double, double> DerivativeFunction { get; set; }

        public KingsFifth_orderMethod_3(
            Func<double, double> func,
            Func<double, double> derivateFunc,
            double multiplicity,
            double initValue,
            double precision)
        {
            this.initValue = initValue;
            this.precision = precision;
            this.multiplicity = multiplicity;
            this.Function = func;
            this.DerivativeFunction = derivateFunc;
        }

        public void DoIterations()
        {
            double t0 = initValue;
            double t = initValue;
            int i = 0;
            do
            {
                i++;
                Console.Write(i.ToString() + " ");
                t0 = t;
                t = CalculateNextValue(t0);
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);

        }

        public void DoIterationsWithoutDer()
        {
            double x_prev = initValue;
            double t0 = initValue;
            double t = initValue;
            int i = 0;
            do
            {
                i++;
                Console.Write(i.ToString() + " ");
                x_prev = t0 + 0.00000001;
                //x_prev = t0 + 0.00000001;
                t0 = t;
                t = CalculateNextValueDiff(t0, x_prev);
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);

        }

        private double CalculateNextValue(double t0)
        {
            double Wn(double x_n) => x_n - Function(x_n) / DerivativeFunction(x_n);

            double H = multiplicity / (multiplicity - 1);

            double A = Pow(H, 2 * multiplicity) - Pow(H, multiplicity + 1);

            double B(double x_n)
            {
                var denominator = Pow(H, multiplicity) * (multiplicity - 2) * (multiplicity - 1) + 1;
                var numerator = Pow(multiplicity - 1, 2);
                return -denominator / numerator;
            }

            var firstFraction = Function(Wn(t0)) / DerivativeFunction(t0);

            var secondFraction = (Function(t0) + A * Function(Wn(t0))) / (Function(t0) + B(t0) * Function(Wn(t0)));

            return Wn(t0) - firstFraction * secondFraction;
        }

        private double CalculateNextValueDiff(double t0, double x_prev)
        {
            double Wn(double x_n) => x_n - Function(x_n) / Differences(Function, x_prev, x_n);

            double H = multiplicity / (multiplicity - 1);

            double A = Pow(H, 2 * multiplicity) - Pow(H, multiplicity + 1);

            double B(double x_n)
            {
                var denominator = Pow(H, multiplicity) * (multiplicity - 2) * (multiplicity - 1) + 1;
                var numerator = Pow(multiplicity - 1, 2);
                return -denominator / numerator;
            }

            var firstFraction = Function(Wn(t0)) / Differences(Function, x_prev, t0);

            var secondFraction = (Function(t0) + A * Function(Wn(t0))) / (Function(t0) + B(t0) * Function(Wn(t0)));

            return Wn(t0) - firstFraction * secondFraction;
        }
    }
}
