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
            string[] countries = { "India", "USA", "Russia", "China", "Australia", "Argentina" };

            var res = countries.Take(4);

            foreach (string s in res)
            {
                Console.WriteLine(s);
            }

        }
    }
}
