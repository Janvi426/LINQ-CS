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
                new Student() { id = 3, name = "Ami" }
            };

            //var res = studentObj.OrderBy(a => a.name);
            var res = studentObj.OrderByDescending(a => a.name);

            foreach (var student in res)
            {
                Console.WriteLine(student.name);
            }
        }


    }

    class Student
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
