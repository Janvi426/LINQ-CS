using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    delegate bool FindStudents(Students std);

    class StudentExtension
    {
        public static Students[] where(Students[] stdArr, FindStudents del)
        {
            int i = 0;
            Students[] res = new Students[10];
            foreach (Students std in stdArr)
            {
                if (del(std))
                {
                    res[i] = std;
                    i++;
                }
            }

            return res;
        }
    }

    class UsingDelegateFindData
    {
        public static void Run()
        {
            Students[] studentArray = {
            new Students() { StudentsID = 1, StudentsName = "John", Age = 18 } ,
            new Students() { StudentsID = 2, StudentsName = "Steve",  Age = 21 } ,
            new Students() { StudentsID = 3, StudentsName = "Bill",  Age = 25 } ,
            new Students() { StudentsID = 4, StudentsName = "Ram" , Age = 20 } ,
            new Students() { StudentsID = 5, StudentsName = "Ron" , Age = 31 } ,
            new Students() { StudentsID = 6, StudentsName = "Chris",  Age = 17 } ,
            new Students() { StudentsID = 7, StudentsName = "Rob",Age = 19  } ,
            };

            Students[] res1 = StudentExtension.where(studentArray, delegate (Students std)
            {
                return std.Age > 12 && std.Age < 20;
            });

            foreach (Students std in res1)
            {
                if (std != null)
                {
                    Console.WriteLine(std.StudentsName + "\t" + std.Age);
                }
            }

            Console.WriteLine("\n---------------------------------------\n");

            Students[] res2 = StudentExtension.where(studentArray, delegate (Students std)
            {
                return std.StudentsName == "Bill" || std.StudentsName == "Ram";
            });

            foreach (Students std in res2)
            {
                if (std != null)
                {
                    Console.WriteLine(std.StudentsName + "\t" + std.StudentsID);
                }
            }


        }
    }

    class Students
    {
        public int StudentsID { get; set; }
        public string StudentsName { get; set; }
        public int Age { get; set; }


    }
}
