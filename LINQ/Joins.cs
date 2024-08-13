using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Joins
    {
        public static void Run()
        {
            // On List
            List<string> strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four"
            };

            List<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };

            var innerJoin = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);

            foreach (var i in innerJoin)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n----------------------------\n");

            // On List of Student1 object
            IList<Student1> studentList = new List<Student1>() {
                new Student1() { Student1ID = 1, Student1Name = "John", StandardID = 1 },
                new Student1() { Student1ID = 2, Student1Name = "Moin", StandardID = 1 },
                new Student1() { Student1ID = 3, Student1Name = "Bill", StandardID = 2 },
                new Student1() { Student1ID = 4, Student1Name = "Ram" , StandardID = 2 },
                new Student1() { Student1ID = 5, Student1Name = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var innerJoin1 = studentList.Join(// outer sequence 
                                  standardList,  // inner sequence 
                                  student => student.StandardID,    // outerKeySelector
                                  standard => standard.StandardID,  // innerKeySelector
                                  (student, standard) => new  // result selector
                                  {
                                      Student1Name = student.Student1Name,
                                      StandardName = standard.StandardName
                                  });

            var innerJoinUsingQuerySyntax = from s in studentList 
                           join st in standardList 
                           on s.StandardID equals st.StandardID 
                           select new
                           { 
                               StudentName = s.Student1Name,
                               StandardName = st.StandardName
                           };

            foreach (var x in innerJoin1)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\n--------------------------------\n");

            // Group Join
            var groupJoin = standardList.GroupJoin(studentList,  
                                std => std.StandardID, 
                                s => s.StandardID,    
                                (std, studentsGroup) => new 
                                {
                                    Students = studentsGroup,
                                    StandarFulldName = std.StandardName
                                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var x in item.Students)
                {
                    Console.WriteLine(x.Student1Name);
                }
            }

            Console.WriteLine("\n--------------------------------\n");

            // ALL  
            bool areAllStudentsInStd1 = studentList.All(s => s.StandardID == 1);
            Console.WriteLine(areAllStudentsInStd1);

            Console.WriteLine("\n--------------------------------\n");

            // Any
            bool areAnyStudentsInStd1 = studentList.Any(s => s.StandardID == 1);
            Console.WriteLine(areAnyStudentsInStd1);

            Console.WriteLine("\n--------------------------------\n");
        }
    }

    class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    class Student1
    {
        public int Student1ID { get; set; }
        public string Student1Name { get; set; }
        public int StandardID { get; set; }
    }

}



