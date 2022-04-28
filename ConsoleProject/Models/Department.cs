using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Department
    {
        private string _name;
        private byte _workerlimit;
        public Employee[] Employes;
        private double _salarylimit;
        public string Name { 
            get => _name;
            set
            {
                while (!Namechecker(value))
                {
                    Console.WriteLine("Duzgun Daxil Et");
                    value = Console.ReadLine();
                }
                _name = value;
            }
        
        }
        public byte WorkerLimit
        {
            get => _workerlimit;
            set
            {
                while (value<10)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("minimum 10 olmalidir");
                    Console.WriteLine("yeniden daxil et");
                    byte.TryParse(Console.ReadLine(), out value);
                }
                _workerlimit = value;
            } 
        }
        public double Salarylimit 
        {
            get => _salarylimit;
            set
            {
                while (!Salarylimitcheck(value))
                {
                    
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("daxil etdiyiniz deyer ayliq budceni asir");
                        Console.WriteLine("yeniden daxil et");
                        double.TryParse(Console.ReadLine(), out value);
                }
                _salarylimit = value;
            } 
        }
        public bool Namechecker(string name)
        {
            while (true)
            {
                if (name.Length >= 2)
                {
                    bool check = true;
                    foreach (char item in name)
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
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("ancaq  herifden ibaret olmalidri");
                        name = Console.ReadLine();
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("minimum 2 herifden ibaret ola biler");
                    name = Console.ReadLine();
                }
            }
        }
        public double CalcSalaryAverage()
        {
            double totalsalary = 0;
            foreach (Employee employee in Employes)
            {
                totalsalary += employee.Salary;
            }
            totalsalary = totalsalary / Employes.Length;
            return totalsalary;
        }
        public bool Salarylimitcheck(double salarylimit)
        {
            double countsalary = _workerlimit * 250;
            if (salarylimit >= countsalary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Department(string name,byte workerlimit, double salarylimit)
        {
            Name = name;
            Employes = new Employee[0];
            WorkerLimit = workerlimit;
            Salarylimit = salarylimit;
        }
    }
    
}
