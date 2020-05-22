using System;
using System.Collections.Generic;
using System.Text;
using static High_order_solvers_for_mutl_root.Helpers;
using static System.Math;

namespace High_order_solvers_for_mutl_root.Methods
{
    class Third_orderbyDong_7
    {
        private readonly double multiplicity;
        private readonly double initValue;
        private readonly double precision;

        public Func<double, double> Function { get; set; }
        public Func<double, double> DerivativeFunction { get; set; }

        public Third_orderbyDong_7(
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
                x_prev = t0 + 0.0000000001;
                t0 = t;
                t = CalculateNextValueDiff(t0, x_prev);
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);
        }

        private double CalculateNextValueDiff(double t0, double x_prev)
        {
            var u_n = this.Function(t0) / Differences(this.Function, x_prev, t0);

            var numerator = multiplicity / (multiplicity + 1) * Function(t0);

            var denominator = Pow(1 + (1 / multiplicity), multiplicity)
                * Differences(this.Function , x_prev - (multiplicity / (multiplicity + 1)) * u_n, t0 - (multiplicity / (multiplicity + 1)) * u_n)
                - Differences(this.Function, x_prev, t0);

            return t0 - (multiplicity / (multiplicity + 1)) * u_n - numerator / denominator;
        }

        private double CalculateNextValue(double t0)
        {
            var u_n = this.Function(t0) / this.DerivativeFunction(t0);

            var numerator = multiplicity / (multiplicity + 1) * Function(t0);

            var denominator = Pow(1 + (1 / multiplicity), multiplicity)
                * DerivativeFunction(t0 - (multiplicity / (multiplicity + 1)) * u_n)
                - DerivativeFunction(t0);

            return t0 - (multiplicity / (multiplicity + 1)) * u_n - numerator / denominator;
        }
    }
}
