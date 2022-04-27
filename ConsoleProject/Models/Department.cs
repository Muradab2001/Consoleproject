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
                        _name = name;
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
        public Department(string name)
        {
            Name = name;
        }
    }
    
}
