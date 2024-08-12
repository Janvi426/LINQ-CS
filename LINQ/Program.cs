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


            //  creating the query using the methods provided by the Enumerable or Queryable static classes  
            var r1 = list.Where(a => a.Contains("C"));

            foreach (var i in r1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
