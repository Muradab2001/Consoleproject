using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name,byte workerlimit,double salarylimit);

        Department[] GetDepartments();
        void EditDepartment(string name);
        void AddEmploye(string fullname, string position, double salary, string DepartmentName);
        void EditEmploye(string fullname,string no,double salary,string position,string departmentname);
        void RemoveEmployee(string no,string departmentname);

    }
}
