using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Employee
    {
        public string DepartmentName { get; set; }
        private string _position;
        private double _salary;
        public  string No;
        private static int _count;
        private string _fullname;

        public string Fullname 
        {
            get => _fullname;
            set
            {
                while (!fullnamechecker(value))
                    
                    {
                        Console.WriteLine("Duzgun Daxil Et");
                        value = Console.ReadLine();
                    }
                _fullname = value;
            } 
        }
        public string Position {

            get => _position;
            set
            {
                while (!positionchecker(value))
                {
                        Console.WriteLine("Duzgun Daxil Et");
                        value = Console.ReadLine();
                    
                    _position = value;
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
            _count = 1000;
        }
        public Employee(string departmentname, string position, double salary,string fullname)
        {
            _count++;
            No = $"{departmentname.Substring(0, 2) }{_count}";
            DepartmentName = departmentname;
            Position = position;
            Fullname = fullname;
           
            Salary = salary;
        }
        public bool fullnamechecker(string fullname)
        {
            return fullname.Split(' ').Length > 2;
        }
        public bool positionchecker(string position)
        {
            while (true)
            {
                if (position.Length >= 2)
                {
                    bool check = true;
                    foreach (char item in position)
                    {
                        if (!char.IsLetter(item))
                        {
                            check = false;
                        }
                    }
                    if (check == true)
                    {
                        return true;
                      
                    }
                    else
                    {
                        Console.WriteLine("ancaq  herifden ibaret olmalidri");
                        position = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("minimum 2 herifden ibaret ola biler");
                    position = Console.ReadLine();
                }
            }
        }
    }
}
