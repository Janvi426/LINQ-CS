using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class PartitionOp
    {
        public static void Run()
        {
            string[] countries = { "US", "UK", "India", "Russia", "China", "Australia", "Argentina" };

            // Take()
            var res = countries.Take(4);

            foreach (string s in res)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // TakeWhile
            var res1 = countries.TakeWhile(a => a.StartsWith("U"));

            foreach (string a in res1)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            string[] countries1 = { "AK", "AP", "AWE", "US", "UK", "Russia", "China", "Australia", "Argentina" };

            // In Query syntax
            var res2 = (from x in countries1 select x).TakeWhile(x => x.StartsWith("A"));

            foreach (string s in res2)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // Skip()

            var res3 = countries.Skip(3);

            foreach (string a in res3)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            // In Query syntax
            var res4 = (from x in countries select x).Skip(3);

            foreach (string a in res4)
            {
                Console.WriteLine(a);
            }
        }
    }
}
