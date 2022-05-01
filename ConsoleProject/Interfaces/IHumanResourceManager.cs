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
        void EditDepartment(string name, string newname, byte workerlimit, double salarylimit);
        void AddEmploye(string fullname, string position, double salary, string DepartmentName);
        void EditEmploye(string no,double salary,string position,string departmentname);
        void RemoveEmployee(string no,string departmentname);

    }
}
