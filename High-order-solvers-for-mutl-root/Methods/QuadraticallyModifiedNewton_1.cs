using System;
using System.Collections.Generic;
using System.Text;
using static High_order_solvers_for_mutl_root.Helpers;

namespace High_order_solvers_for_mutl_root.Methods
{
    class QuadraticallyModifiedNewton_1
    {
        private readonly double multiplicity;
        private readonly double initValue;
        private readonly double precision;

        public Func<double, double> Function { get; set; }
        public Func<double, double> DerivativeFunction { get; set; }

        public QuadraticallyModifiedNewton_1(
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
                t = t0 - (multiplicity * Function(t0) / DerivativeFunction(t0));
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
                x_prev = t0 + 0.000000000001;
                t0 = t;
                t = t0 - (multiplicity * Function(t0) / Differences(Function, x_prev, t0));
                DisplayValue(t, 5);
            } while (Math.Abs((t - t0)) > this.precision);

            Console.ReadLine();
        }
    }
}
