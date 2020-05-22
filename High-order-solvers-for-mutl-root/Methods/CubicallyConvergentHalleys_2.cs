using System;
using System.Collections.Generic;
using System.Text;
using static High_order_solvers_for_mutl_root.Helpers;

namespace High_order_solvers_for_mutl_root.Methods
{
    class CubicallyConvergentHalleys_2
    {
        public Func<double, double> Function { get; }
        public Func<double, double> DerivateFunction { get; }
        public Func<double, double> DerivateDerivateFunction { get; }

        private readonly double multiplicity;
        private readonly double initValue;
        private readonly double precision;

        public CubicallyConvergentHalleys_2(
            Func<double, double> func,
            Func<double, double> derivateFunc,
            Func<double, double> derivateDerivateFunc,
            double multiplicity,
            double initValue,
            double precision)
        {
            this.Function = func;
            this.DerivateFunction = derivateFunc;
            this.DerivateDerivateFunction = derivateDerivateFunc;
            this.multiplicity = multiplicity;
            this.initValue = initValue;
            this.precision = precision;
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
                t = GetNextValue(t0);
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);

        }

        private double GetNextValue(double t0)
        {
            var denominator1 = ((multiplicity + 1) / (2 * multiplicity)) * DerivateFunction(t0);

            var d2 = (Function(t0) * DerivateDerivateFunction(t0)) / (2 * DerivateFunction(t0));

            return t0 - Function(t0) / (denominator1 - d2);
        }

        public void DoIterationsWithoutDer()
        {
            double x_prev_prev = initValue;
            double x_prev = initValue;
            double t0 = initValue;
            double t = initValue;
            int i = 0;
            do
            {
                i++;
                Console.Write(i.ToString() + " ");
                x_prev_prev = x_prev - 0.000000003;
                x_prev = t0 + 0.000000001;
                t0 = t;
                t = GetNextValueDif(t0, x_prev, x_prev_prev);
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);


            Console.ReadLine();
        }

        private double GetNextValueDif(double t0, double x_prev, double x_prev_prev)
        {
            var denominator1 = ((multiplicity + 1) / (2 * multiplicity)) * Differences(this.Function, x_prev, t0);

            var d2 = (Function(t0) * Difference_Sencond(this.Function, x_prev_prev, x_prev, t0)) / (2 * Differences(this.Function, x_prev, t0));

            return t0 - Function(t0) / (denominator1 - d2);
        }
    }
}
