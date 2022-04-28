using ConsoleProject.Interfaces;
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
            if (DepartmentFindName(name) == null)
            {
                Department department = new Department(name, workerlimit, salarylimit);
                Array.Resize(ref _departmentarr, _departmentarr.Length + 1);
                _departmentarr[_departmentarr.Length - 1] = department;
            }
            else
            {
                Console.WriteLine("eyni adda 2 ci sirket adi ola bilmez");
            }
        }

        public Department[] GetDepartments()
        {
            return _departmentarr;
        }

        public void EditDepartment(string name)
        {
            Department department = DepartmentFindName(name);

            if (department != null)
            {
                department.Name = name;
                foreach (Employee employee in department.Employes)
                {
                    employee.No.Replace(employee.No.Substring(0, 2), department.Name.Substring(0, 2).ToUpper());
                    employee.DepartmentName = name;
                }
            }
            Console.WriteLine($"daxil etdiyiniz {name} qurup yoxdur ");
        }
        public Department DepartmentFindName(string name)
        {
            foreach (Department department in _departmentarr)
            {
                if (department.Name == name.ToUpper())
                {
                    return department;
                }
            }
            return null;
        }
    }
}

