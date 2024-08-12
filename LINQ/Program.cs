using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating data source
            List<string> list = new List<string>()
            {
                "Hello",
                "Hi! janvi",
                "C sharp learning",
                "C sharp program",
                "janvi writing"
            };


            // creating LINQ query for data source - QUERY SYNTAX
            var r = from l in list
                    where l.Contains("janvi")
                    select l;

            //Console.WriteLine(r);  // Enumerable<string> list that contains string having 'janvi'

            // executing LINQ qury using for each loop
            foreach (var i in r)
            {
                Console.WriteLine(i);
            }


            //  METHOD SYNTAX - creating the query using the methods provided by the Enumerable or Queryable static classes  
            var r1 = list.Where(a => a.Contains("C")); // LAMBDA Expression

            foreach (var i in r1)
            {
                Console.WriteLine(i);
            }

            // MIXED SYNTAX
            List<int> integerList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var r2 = (from num in integerList
                      where num > 5
                      select num).Sum();

            Console.WriteLine("sum : " + r2);

            // LAMBDA Expression
            var r3 = list.Select(a => a);
        }
    }
}
