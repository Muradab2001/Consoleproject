using ConsoleProject.Models;
using ConsoleProject.Services;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                HumanResourceManager humanResourceManager = new HumanResourceManager();
                Console.Clear();
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
                        addDepartment(ref humanResourceManager);
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        
                        break;
                    case 4:
                       
                        break;
                    case 5:
                        
                        break;
                    case 6:
                       
                        break;
                    case 7:
                      
                        break;
                    case 8:
                        return;

                }
            } while (true);
        }
        static void addDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Sobenin adini daxil et");
            string choosename = Console.ReadLine();
            Console.WriteLine("sobenin isci limitin daxil et");
            byte.TryParse(Console.ReadLine(),out byte workerlimit);
            Console.WriteLine("sobenin budcesi daxil et");
            double.TryParse(Console.ReadLine(), out double salarylimit);
            
            Department department = new Department(choosename,workerlimit,salarylimit);
      
        }
    }
}
