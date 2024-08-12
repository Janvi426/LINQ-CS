using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class ConvertionOp
    {
        public static void Run()
        {
            string[] names = { "Janvi", "Helli", "Krishna", "Janu" };

            // ToList()
            List<string> result = names.ToList();

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // ToArray()
            string[] res = result.ToArray();

            foreach (string s in res)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // ToLookup() 
            List<Employee> objEmployee = new List<Employee>()
            {
                new Employee(){ Name="Akshay Tyagi", Department="IT", Country="India"},
                new Employee(){ Name="Vaishali Tyagi", Department="Marketing", Country="Australia"},
                new Employee(){ Name="Arpita Rai", Department="HR", Country="China"},
                new Employee(){ Name="Shubham Ratogi", Department="Sales", Country="USA"},
                new Employee(){ Name="Himanshu Tyagi", Department="Operations", Country="Canada"},
                new Employee(){ Name="Roni Moni", Department="Operations", Country="India"},

            };

            var emp = objEmployee.ToLookup(x => x.Department);

            Console.WriteLine("Grouping Employees by Department");
            Console.WriteLine("---------------------------------");
            foreach (var KeyValurPair in emp)
            {
                Console.WriteLine(KeyValurPair.Key);
                // Lookup employees by Department  
                foreach (var item in emp[KeyValurPair.Key])
                {
                    Console.WriteLine("\t" + item.Name + "\t" + item.Department + "\t" + item.Country);
                }
            }

            Console.WriteLine();

            // Cast()
            // Create a non-generic ArrayList containing integers
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            // Use Cast<int>() to cast elements to integers
            var res1 = list.Cast<int>();

            // Now we can use LINQ methods on the result
            var evenNumbers = res1.Where(n => n % 2 == 0);

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number); 
            }

            Console.WriteLine();

            // OfType()
            ArrayList obj = new ArrayList();
            obj.Add("Australia");
            obj.Add("India");
            obj.Add(2);
            obj.Add("USA");
            obj.Add(1);

            var res2 = obj.OfType<int>();

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // AsEnumerable()
            int[] NumArray = new int[] { 1, 2, 3, 4, 5 };

            var res3 = NumArray.AsEnumerable();

            foreach (var number in res3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // ToDictionary()
            var res4 = objEmployee.ToDictionary(x => x.Name, x => x.Department);

            foreach (var a in res4)
            {
                Console.WriteLine(a.Key + "\t" + a.Value);
            }

            Console.WriteLine();
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
    }
}
