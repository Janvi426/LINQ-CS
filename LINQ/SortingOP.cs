using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    static class SortingOP
    {
        public static void Run()
        {
            List<Student> studentObj = new List<Student>()
            {
                new Student() { id = 1, name = "Janvi" },
                new Student() { id = 2, name = "Helli" },
                new Student() { id = 3, name = "Ami" },
                new Student() { id = 4, name = "Janvi" }
            };

            //var res = studentObj.OrderBy(a => a.name);
            var res = studentObj.OrderByDescending(a => a.name);

            foreach (var student in res)
            {
                Console.WriteLine(student.name);
            }

            Console.WriteLine("\n");

            //var res1 = studentObj.OrderBy(a => a.name).ThenBy(a => a.id);
            var res1 = studentObj.OrderBy(a => a.name).ThenByDescending(a => a.id);

            foreach (var student in res1)
            {
                Console.WriteLine("name = {0}, id = {1}", student.name, student.id);
            }
        }


    }

    class Student
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
