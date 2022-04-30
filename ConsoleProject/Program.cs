using ConsoleProject.Models;
using ConsoleProject.Services;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("=====Welcome Couse Management======\n");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Reqemini Daxil Et\n");
                Console.WriteLine("1. Sobe elave etmek:");
                Console.WriteLine("2. isci elave etmek:");
                Console.WriteLine("3. Sobe uzerinde deyisiklik et:");
                Console.WriteLine("4. isci Uzerinde Deyisiklik Et:");
                Console.WriteLine("5. Sobe siyahisi:");
                Console.WriteLine("6. Sobenin isci  Siyahisi:");
                Console.WriteLine("7. umumi isci Siyahisi:");
                Console.WriteLine("8. iscinin silinmesi:");
                Console.WriteLine("9. Sistemden Cix:");
                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    choose = Console.ReadLine();
                }
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        addEmployee(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        EditEmploye(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        Getdepartamentemploye(ref humanResourceManager);
                        break;
                    case 7:
                        Getallemoloyee(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;

                }

            } while (true);
        }
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Sobenin adini daxil et");
            string Chosedepartmentname = Console.ReadLine();
            while (string.IsNullOrEmpty(Chosedepartmentname) || Chosedepartmentname.Contains(' '))
            {
                Console.WriteLine("sobenin adi bos gonderlile bilmez!!!");
                Chosedepartmentname = Console.ReadLine();
            }
            Console.WriteLine("sobenin isci limitin daxil et");
            string Chooseworkerlimit = Console.ReadLine();
            while (string.IsNullOrEmpty(Chooseworkerlimit) || Chooseworkerlimit.Contains(' '))
            {
                Console.WriteLine("sobenin isci limiti bos ola bilmez!!");
                Chooseworkerlimit = Console.ReadLine();
            }
            byte.TryParse(Chooseworkerlimit, out byte workerlimit);
            Console.WriteLine("sobenin budcesi daxil et");
            string Salarylimitcheck = Console.ReadLine();
            while (string.IsNullOrEmpty(Salarylimitcheck) || Salarylimitcheck.Contains('.') || Salarylimitcheck.Contains(' '))
            {
                Console.WriteLine("budce limitin bos ola bilmez!!");
                Salarylimitcheck = Console.ReadLine();
            }
            double.TryParse(Salarylimitcheck, out double salarylimit);
            humanResourceManager.AddDepartment(Chosedepartmentname, workerlimit, salarylimit);
        }
        static void addEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("iscini hansi sobeye salmaq isteyirsiniz");
            string Departamentname = Console.ReadLine();
            Console.WriteLine("iscinin adini daxil et");
            string employename = Console.ReadLine();
            Console.WriteLine("iscinin maasin daxil edin");
            double.TryParse(Console.ReadLine(), out double salary);
            Console.WriteLine("iscinin vezifesin daxil edin");
            string position = Console.ReadLine();
            humanResourceManager.AddEmploye(employename, position, salary, Departamentname.ToUpper());
        }
        static void EditDepartment(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("deyisdirmey istediyin sobeni sec");
            string Departamentname = Console.ReadLine();
            Console.WriteLine("yeni sobe adin daxil et");
            string Departamentnamenew = Console.ReadLine();
            humanResourceManager.EditDepartment(Departamentname, Departamentnamenew);
        }
        static void EditEmploye(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("deyismek istediyiniz iscinin qurupun daxil edin");
            string departmentname = Console.ReadLine();
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employes)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("deyismek istediyiniz isci nomresin daxil edin");
            string no = Console.ReadLine();
            Console.WriteLine("iscinin gelirini daxil edin");
            double.TryParse(Console.ReadLine(), out double employeesalary);
            Console.WriteLine("iscinin veifesini daxil edin");
            string employeposition = Console.ReadLine();

            humanResourceManager.EditEmploye(no, employeesalary, employeposition, departmentname);


        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
        }
        static void Getdepartamentemploye(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("iscisine baxmaq istediyiniz sobeni secin");
            string departmentname = Console.ReadLine();
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employes)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void Getallemoloyee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employes)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department department in humanResourceManager.Departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("silmey istediyiniz iscinin qrupunu daxil edin");
            string departmentname = Console.ReadLine();
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employes)
                {
                    Console.WriteLine(employee);
                }
            }
            Console.WriteLine("silmek istediyiniz iscinin no daxil edin");
            string no = Console.ReadLine();
            humanResourceManager.RemoveEmployee(no, departmentname);
        }
        
    }
}
