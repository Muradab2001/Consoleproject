using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Employee
    {
        public string DepartmentName;
        private string _position;
        private double _salary;
        public string No;
        private static int count;
        public string Fullname { get; set; }

   
        public string Position {

            get => _position;
            set
            {
                bool Loopcheck = true;
                while (Loopcheck)
                {
                    if (value.Length >= 2)
                    {
                        bool check = true;
                        foreach (char item in value)
                        {
                            if (!char.IsLetter(item))
                            {
                                check = false;
                            }
                        }
                        if (check == true)
                        {
                            _position = value;
                            Loopcheck = false;
                        }
                        else
                        {
                            Console.WriteLine("ancaq  herifden ibaret olmalidri");
                            value = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("minimum 2 herifden ibaret ola biler");
                        value = Console.ReadLine();
                    }
                }
            } 
        }
        public double Salary 
        {
            get => _salary;
            set
            {
                while (value < 250)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("250 cox olmalidir");
                    Console.WriteLine("yeniden daxil et");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            } 
        }
        static Employee()
        {
            count = 1000;
        }
        public Employee(string departmentname)
        {
            count++;
            No = $"{departmentname.Substring(0, 2) }{count}";
        }
        public Employee(string position,double salary)
        {
            Position = position;
            Salary = salary;
        }
    }
}
