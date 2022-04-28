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

    }
}
