using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Generic Methods *****\n");

            //Swap 2 ints
            int oneInt = 24;
            int twoInt = 65;
            Console.WriteLine("Int befor swap - {0}; {1}", oneInt, twoInt);

            MyGenericMethods.Swap<int>(ref oneInt, ref twoInt);

            Console.WriteLine("Int after swap - {0}; {1}", oneInt, twoInt);

            // Swap 2 strings.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}!", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}!", s1, s2);

            // Compiler will infer System.Boolean.
            bool b1 = true, b2 = false;
            Console.WriteLine("Before swap: {0}, {1}", b1, b2);
            Swap(ref b1, ref b2);
            Console.WriteLine("After swap: {0}, {1}", b1, b2);

            // Must supply type parameter if
            // the method does not take params.
            DisplayBaseClass<int>();
            DisplayBaseClass<string>();
            // Compiler error! No params? Must supply placeholder!
            // DisplayBaseClass();
            Console.ReadLine();
        }
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }
        static void DisplayBaseClass<T>()
        {
            // BaseType is a method used in reflection,
            // which will be examined in Chapter 15
            Console.WriteLine("Base class of {0} is: {1}.", typeof(T), typeof(T).BaseType);
        }
    }
    public static class MyGenericMethods
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }
        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is: {1}.", typeof(T), typeof(T).BaseType);
        }
    }
}
