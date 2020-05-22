using High_order_solvers_for_mutl_root.Methods;
using System;
using static System.Math;

namespace High_order_solvers_for_mutl_root
{
    class Program
    {
        static class Ex1
        {
            public static Func<double, double> func = x => Pow(x, 5) - 8 * Pow(x, 4) + 24 * Pow(x, 3) - 34 * Pow(x, 2) + 23 * x - 6;

            public static Func<double, double> derivateFunc = x => 5 * Pow(x, 4) - 32 * Pow(x, 3) + 72 * Pow(x, 2) - 68 * x + 23;

            public static Func<double, double> derivateВerivateFunc = x => 20 * Pow(x, 3) - 96 * Pow(x, 2) + 144 * x - 68;

            public static int M { get; set; } = 3;
        }

        static class Ex2
        {
            public static Func<double, double> func = x => x * x * Exp(x);

            public static Func<double, double> derivateFunc = x => Exp(x) * x * (x + 2);

            public static Func<double, double> derivateВerivateFunc = x => Exp(x) * (x * x + 4 * x + 2);
            public static int M { get; set; } = 2;
        }

        // QuadraticallyModifiedNewton_1 - verified  + нютон кубічний 
        // CubicallyConvergentHalleys_2 - verified +  галлея
        // KingsFifth_orderMethod_3 - verified +    вікторії
        // Third_orderbyDong_6 - verified +  донга 1
        // Third_orderbyDong_7 - verified  + донга 2


        /* В кожному класі є по 2 методи, 
         * DoIterations виконує ітерації з похідними
         * DoIterationsWithoutDer з заміненою проксимацією
         * */

        static void Main(string[] args)
        {
            var mathod1 = new Third_orderbyDong_7(
                Ex2.func,
                Ex2.derivateFunc,
                //Ex2.derivateВerivateFunc,
                Ex2.M,      ///m
                -1.5,   //value
                0.000001);

            mathod1.DoIterations();
            Console.WriteLine();
            Console.WriteLine("DIFFFFFFF");
            mathod1.DoIterationsWithoutDer();

            Console.ReadLine();
        }
    }
}
