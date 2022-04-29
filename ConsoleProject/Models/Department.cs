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
                while (value<0)
                {
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
                        Console.WriteLine("daxil etdiyiniz deyer ayliq budceni asir");
                        Console.WriteLine("yeniden daxil et");
                        double.TryParse(Console.ReadLine(), out value);
                }
                _salarylimit = value;
            } 
        }
        public bool Namechecker(string name)
        {
            if (name.Length >=2)
            {
                foreach (var item in name)
                {
                    if (!char.IsLetter(item))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public double CalcSalaryAverage()
        {
            double totalsalary = 0;
            if (Employes.Length>=1)
            {
            
                foreach (Employee employee in Employes)
                {
                    totalsalary += employee.Salary;
                }
                totalsalary = totalsalary / Employes.Length;
                return totalsalary;
            }
            return totalsalary;
        }
        public bool Salarylimitcheck(double salarylimit)
        {
          
            if (salarylimit >= _workerlimit * 250)
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
        public override string ToString()
        {
            return $"sobenin adi: {_name} sobenin isci limiti: {_workerlimit} sobenin limiti {_salarylimit}";
        }
    }
    
}
