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


            // creating LINQ query for data source 
            var r = from l in list
                    where l.Contains("janvi")
                    select l;

            // executing LINQ qury using for each loop
            foreach (var i in r)
            {
                Console.WriteLine(i);
            }
        }
    }
}
