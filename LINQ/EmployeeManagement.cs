using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class EmployeeManagement
    {
        public static void Run()
        {
            List<Employees> empList = new List<Employees>()
            {
            new Employees { Id = 1, Name = "Alice Smith", Department = "HR", Salary = 75000, JoiningDate = new DateTime(2019, 6, 15), PerformanceRating = 4 },
            new Employees { Id = 2, Name = "Bob Johnson", Department = "IT", Salary = 95000, JoiningDate = new DateTime(2020, 1, 22), PerformanceRating = 5 },
            new Employees { Id = 3, Name = "Charlie Davis", Department = "IT", Salary = 85000, JoiningDate = new DateTime(2018, 8, 30), PerformanceRating = 4 },
            new Employees { Id = 4, Name = "Diana Lee", Department = "Finance", Salary = 90000, JoiningDate = new DateTime(2021, 3, 10), PerformanceRating = 5 },
            new Employees { Id = 5, Name = "Evan White", Department = "Marketing", Salary = 72000, JoiningDate = new DateTime(2022, 7, 25), PerformanceRating = 3 },
            new Employees { Id = 6, Name = "Fiona Brown", Department = "HR", Salary = 78000, JoiningDate = new DateTime(2017, 5, 15), PerformanceRating = 4 },
            new Employees { Id = 7, Name = "George Miller", Department = "IT", Salary = 89000, JoiningDate = new DateTime(2019, 11, 18), PerformanceRating = 5 },
            new Employees { Id = 8, Name = "Hannah Wilson", Department = "Finance", Salary = 92000, JoiningDate = new DateTime(2018, 9, 8), PerformanceRating = 4 },
            new Employees { Id = 9, Name = "Isaac Moore", Department = "Marketing", Salary = 68000, JoiningDate = new DateTime(2020, 4, 14), PerformanceRating = 3 },
            new Employees { Id = 10, Name = "Jack Taylor", Department = "Finance", Salary = 95000, JoiningDate = new DateTime(2019, 2, 20), PerformanceRating = 5 },
            new Employees { Id = 11, Name = "Karen Anderson", Department = "HR", Salary = 71000, JoiningDate = new DateTime(2021, 12, 1), PerformanceRating = 3 },
            new Employees { Id = 12, Name = "Louis Thomas", Department = "IT", Salary = 92000, JoiningDate = new DateTime(2021, 10, 30), PerformanceRating = 4 },
            new Employees { Id = 13, Name = "Mia Martinez", Department = "Marketing", Salary = 69000, JoiningDate = new DateTime(2022, 6, 5), PerformanceRating = 4 },
            new Employees { Id = 14, Name = "Nate Jackson", Department = "Finance", Salary = 88000, JoiningDate = new DateTime(2020, 11, 23), PerformanceRating = 3 },
            new Employees { Id = 15, Name = "Olivia Robinson", Department = "HR", Salary = 76000, JoiningDate = new DateTime(2023, 1, 15), PerformanceRating = 5 }
            };

            // 1. Aggregate Function
            var avgSalaryByDept = empList.GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgSalary = g.Average(e => e.Salary),
                    AvgRating = empList.Average(e => e.PerformanceRating)
                }).ToList();

            foreach (var d in avgSalaryByDept)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("\n---------------------------------------------------\n");

            // 2. Sorting Operation 

            // Sort employees by their performance rating in descending order, and then by salary
            // in ascending order within each rating group.
            var sortedByRating = empList.OrderByDescending(e => e.PerformanceRating).ThenBy(e => e.Salary);

            foreach(var emp in sortedByRating)
            {
                Console.WriteLine("Name = {0}, PRank = {1}, Salary = {2}", emp.Name, emp.PerformanceRating, emp.Salary);
            }

            Console.WriteLine("\n---------------------------------------------------\n");

            // Sort employees by the number of years since joining in ascending order,
            // but only include those with a performance rating of 4 or higher.
            var sortedByYears = empList.Where(e => (DateTime.Now - e.JoiningDate).Days / 365 >= 1 && e.PerformanceRating >= 4)
                .OrderBy(e => (DateTime.Now - e.JoiningDate).Days / 365) 
                .ToList();

            foreach (var employee in sortedByYears)
            {
                int yearsWithCompany = (DateTime.Now - employee.JoiningDate).Days / 365;
                Console.WriteLine($"Name: {employee.Name}, Years with Company: {yearsWithCompany}, Performance Rating: {employee.PerformanceRating}");
            }

            Console.WriteLine("\n---------------------------------------------------\n");


            // 3. Partition Operation

            // Identify the top 10% of employees based on salary and
            // list their names and salaries.
            var take10PercentageEmp = empList.OrderByDescending(e => e.Salary)
                .Take((int)(empList.Count * 0.1))
                .Select(e => new { e.Name, e.Salary })
                .ToList();

            foreach (var emp in take10PercentageEmp)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\n---------------------------------------------------\n");


            // Skip employees who have joined within the last 2 years
            // and retrieve the rest.
            var joinedWithinLast2yr = empList.Where(e => (DateTime.Now - e.JoiningDate).Days / 365 > 2)
                .ToList();

            foreach (var e in joinedWithinLast2yr)
            {
                int years = (DateTime.Now - e.JoiningDate).Days / 365;
                Console.WriteLine($"Name: {e.Name},\t Years with Company: {years}");

            }

            Console.WriteLine("\n---------------------------------------------------\n");


            // 4. Conversion Operation

            // Create a dictionary where the key is the department name and the
            // value is a list of employees in that department.
            var getDictionary = empList.GroupBy(e => e.Department)
                .ToDictionary(x => x.Key, x => x.ToList());

            foreach (var e in getDictionary)
            {
                Console.WriteLine("Department = " + e.Key);
                foreach (var emp in e.Value)
                {
                    Console.WriteLine($"Name: {emp.Name}");
                }
            }

            Console.WriteLine("\n---------------------------------------------------\n");

            // Create a lookup of employees grouped by performance rating
            var ratingLookup = empList.ToLookup(e => e.PerformanceRating);

            foreach (var e in empList)
            {
                Console.WriteLine(e.PerformanceRating);
                foreach(var x in ratingLookup)
                {
                    Console.WriteLine(e.Name);

                }
            }

        }
    }

    class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public int PerformanceRating { get; set; }
    }
}
