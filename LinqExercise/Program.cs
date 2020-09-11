using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */



            //Print the Sum and Average of numbers
            Console.WriteLine("Sum");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("Average");
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("______________________________________________");
            Console.WriteLine("Numbers in Ascending order");
            IEnumerable<int> orderedList = numbers.OrderBy(number => number).ToList();
            foreach (var number in orderedList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Numbers in Desecending order");
            IEnumerable<int> reversedOrderedList = numbers.OrderByDescending(number => number).ToList();
            foreach (var number in reversedOrderedList)
            {
                Console.WriteLine(number);
            }

            //Print to the console only the numbers greater than 6
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Numbers greater than 6");
            IEnumerable<int> greaterThanSix = numbers.Where(num => num > 6);
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Only the first 4 numbers in Ascending order list");
            foreach (var num in orderedList.Take(4))
            {
                Console.WriteLine(num);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Changing index[4] to my age, then printing list in descending order");
            numbers[4] = 27;

            IEnumerable<int> numbersWithAgeSortedDescending = numbers.OrderByDescending(num => num);
            foreach (var num in numbersWithAgeSortedDescending)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Employees name that starts with C or S");
            IEnumerable<Employee> filtered = 
                employees.Where(person => 
                person.FirstName.StartsWith('C') || 
                person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Employees FullName that has age over 26, ordered by age, then first name");

            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Sum of all Years of Experience");
            var yoeSum = employees.Select(emp => emp.YearsOfExperience).Sum();
            Console.WriteLine(yoeSum);
            
            Console.WriteLine();
           
            Console.WriteLine("Average of all Years of Experience");
            var yoeAvg = employees.Select(emp => emp.YearsOfExperience).Average();
            Console.WriteLine(yoeAvg);
            
            Console.WriteLine();
            
            Console.WriteLine("Now Sum & Average for Employees whos YOE <= 10 && Age > 35");
            var bothYOEage = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            foreach (var emp in bothYOEage)
            {
                Console.WriteLine($"{emp.FullName}, {emp.YearsOfExperience}");

            }
            Console.Write($"Years of Experience --- Sum: {bothYOEage.Sum(emp => emp.YearsOfExperience)}, " +
                $"Average: {bothYOEage.Average(emp => emp.YearsOfExperience)}");

            

            //Add an employee to the end of the list without using employees.Add()


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
