using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR17
{
    delegate double formula(double num);

    class Program
    {
        static  void input_arr(double[] arr, string s)
        {
            Console.WriteLine("\nEnter array");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{s}[{i}] = ");
                arr[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine();
        }

        static void sum(double[] arr, out double A, out double B, formula Fa, formula Fb)
        {
            double s = 0, p = 1, flag = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i];
                p *= arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                
                if (arr[i] <= 0)
                {
                    flag += arr[i] * Fa(arr[i]);
                }
            }

            A = s * flag;
            flag = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    flag += arr[i] * Fb(arr[i]);
                }
            }

            B = p * flag;
            flag = 0;

        }


        static void Main(string[] args)
        {
            int size_alpha, size_beta;
            Console.Write("Enter size of array alpha: ");
            size_alpha = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter size of array beta: ");
            size_beta = Convert.ToInt32(Console.ReadLine());

            double[] alpha = new double[size_alpha];
            double[] beta = new double[size_beta];

            input_arr(alpha, "alpha");
            input_arr(beta, "beta");

            double A, B, C, D, l;

            sum(alpha, out A, out B, Math.Sin, Math.Tan);
            sum(beta, out C, out D, Math.Cos, Math.Sin);

            if (Math.Cos(D) + Math.Sin(C) != 0)
            {
                l = (A + B * Math.Sin(A)) / (Math.Cos(D) + Math.Sin(C));

                Console.WriteLine($"Function l = {l}");
            }
            else Console.WriteLine("Denominator can't be equal to 0");

            Console.ReadKey();
        }
    }
}
