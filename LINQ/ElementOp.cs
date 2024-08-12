using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class ElementOp
    {
        public static void Run()
        {
            int[] intObj = { 1, 2, 3, 4 };

            // First()
            int first = intObj.First();
            //int first = (from i in intObj select i).First();

            Console.WriteLine("Element first : " + first);

            // FirstOrDefault()
            string[] emt = { };

            string val = emt.FirstOrDefault(); // null if int[] then 0 default
            Console.WriteLine("Element from the empty list: {0}", val); // null

            Console.WriteLine("---------------------------------");

            // Last()
            int last = intObj.Last();
            //int first = (from i in intObj select i).First();

            Console.WriteLine("Element last : " + last);

            // FirstOrDefault()
            int[] emt1 = { };

            int lastVal = emt1.LastOrDefault(); // null if int[] then 0 default
            Console.WriteLine("Element from the empty list: {0}", lastVal); // null

            Console.WriteLine("---------------------------------");

            // ElementAt()
            int el = intObj.ElementAt(2);
            Console.WriteLine("Element at idx 2 : " + el);

            // ElementAtOrDefault()
            int el1 = emt1.ElementAtOrDefault(2);
            Console.WriteLine("Element at ind 2 in empty : " + el1);

            Console.WriteLine("---------------------------------");

            // Single()
            List<int> numbers = new List<int> { 10, 20, 30 };

            int single = numbers.Single(n => n == 20);

            Console.WriteLine(single);

            try
            {
                int single1 = numbers.Single(n => n > 10);
                Console.WriteLine(single1);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("---------------------------------");

            // SingleOrDefault() 
            int sd = numbers.SingleOrDefault(n => n > 40);

            Console.WriteLine(sd);
            
            try
            {
                int sd1 = numbers.SingleOrDefault(n => n > 10);
                Console.WriteLine(sd1);
            } catch (Exception e) 
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("---------------------------------");

            // DefaultEmpty()
            int[] b = { };
            int[] a = { 1, 2, 3, 4, 5 };

            var result = a.DefaultIfEmpty();
            var result1 = b.DefaultIfEmpty(); // 0, if string[] b then null

            Console.WriteLine("----List1 with Values----");
            foreach (var val1 in result)
            {
                Console.WriteLine(val1);
            }
            Console.WriteLine("---List2 without Values---");
            foreach (var val2 in result1)
            {
                Console.WriteLine(val2);
            }
        }
    }
}
