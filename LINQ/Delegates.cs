using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Delegates is used before LINQ that defines the signature and applied method should have same signature 

public delegate void MyDelegate(string msg); // declaring a delegate

namespace LINQ
{

    class Delegates
    {
        public static void Run()
        {
            MyDelegate del = ClassA.MethodA; // set delegate target
            del("Hello Janvi!!"); // invoke delegate

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            InvokeDelegate(del);
        }

        static void InvokeDelegate(MyDelegate del) // MyDelegate type parameter
        {
            del("Hello Jannnu!!");
        }
    }

    class ClassA
    {
        internal static void MethodA(string msg)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + msg);

        }
    }
}
