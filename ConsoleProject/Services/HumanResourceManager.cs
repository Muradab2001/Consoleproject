﻿using ConsoleProject.Interfaces;
using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departmentarr;
        public Department[] Departments { get => _departmentarr; }
        public HumanResourceManager()
        {
            _departmentarr = new Department[0];
        }
        public void AddDepartment(string name, byte workerlimit, double salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            if (DepartmentFindName(department.Name) != null)
            {
                Console.WriteLine("eyni adda 2 ci sirket adi ola bilmez");
                return;
            }
            Array.Resize(ref _departmentarr, _departmentarr.Length + 1);
            _departmentarr[_departmentarr.Length - 1] = department;
         
        }

        public Department[] GetDepartments()
        {
            return _departmentarr;
        }

        public void EditDepartment(string name, string newname, byte workerlimit, double salarylimit)
        {
            Department departmentold = DepartmentFindName(name);
            Department departmentnew = DepartmentFindName(newname);

            if (departmentold != null)
            {
                if (departmentnew == null)
                {
                    if (departmentold.Employes.Length < workerlimit)
                    {
                        departmentold.WorkerLimit = workerlimit;
                    }
                    else
                    {
                        Console.WriteLine("isci limiti sirketdeki iscilerden az ola bilmez");
                        return;
                    }
                    departmentold.Name = newname;
                    departmentold.Salarylimit = salarylimit;
                    foreach (Employee employee in departmentold.Employes)
                    {
                        employee.DepartmentName = newname;
                        employee.No=employee.DepartmentName.Substring(0, 2).ToUpper()+ employee.No.Substring(2);
                    }
                    return;
                }
                Console.WriteLine($"daxil etdiyiniz yeni qurup adi movcuddu");
                return;
            }
            Console.WriteLine($"daxil etdiyiniz {name} qurup yoxdur ");
        }

        public Department DepartmentFindName(string name)
        {
            foreach (Department department in _departmentarr)
            {
                while (department.Name.ToUpper() == name.ToUpper())
                {
                    return department;
                }
            }
            return null;

        }
        public void AddEmploye(string fullname, string position, double salary, string DepartmentName)
        {
            Department department = DepartmentFindName(DepartmentName);
            if (department != null)
            {
                if (department.WorkerLimit > department.Employes.Length)
                {
                    if ((department.CalcSalaryAverage() * department.Employes.Length) + salary > department.Salarylimit)
                    {
                        Console.WriteLine("maas heddi asildi");
                        return;
                    }
                    Employee departments = new Employee(DepartmentName, position, salary, fullname);
                    Array.Resize(ref department.Employes, department.Employes.Length + 1);
                    department.Employes[department.Employes.Length - 1] = departments;
                    return;
                }
                Console.WriteLine("isci limiti doludu!!");
                return;
            }
            Console.WriteLine($"daxil etdiyiniz {DepartmentName} qurup yoxdur ");
            return;
        }

        public void EditEmploye(string no, double salary, string position, string departmentname)
        {
            Department department = DepartmentFindName(departmentname);
            if (department != null)
            {
                foreach (Employee employee in department.Employes)
                {
                    if (employee.No == no.ToUpper())
                    {
                        if (((department.CalcSalaryAverage() * department.Employes.Length) - employee.Salary) + salary > department.Salarylimit)
                        {
                            Console.WriteLine("maas heddi asib");
                            return;
                        }
                        employee.Position = position;
                        employee.Salary = salary;
                        employee.DepartmentName = departmentname;
                    }
                }
                Console.WriteLine("axtarilan isci yoxdu");
            }
            
        }

        public void RemoveEmployee(string no, string departmentname)
        {
            Department department = DepartmentFindName(departmentname);
            if (department != null)
            {
                for (int i = 0; i < department.Employes.Length; i++)
                {
                    if (department.Employes[i].No.ToUpper() == no.ToUpper())
                    {
                        department.Employes[i] = department.Employes[department.Employes.Length - 1];
                        Array.Resize(ref department.Employes, department.Employes.Length - 1);
                        return;
                    }
                }
                Console.WriteLine($"bele isci nomresi {no} yoxdur");
                return;
            }
            Console.WriteLine($"bu adda {department} yoxdur");
            return;
        }
    }
}


