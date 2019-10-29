using System;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace BusPark
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=A-305-03;Database=BusPark;Trusted_Connection=True;";
        static BusRepos bus = new BusRepos(CONNECTION_STRING);
        static ServiceRepos serviceRepos = new ServiceRepos(CONNECTION_STRING);
        static MechanicRepos mechanicRepos = new MechanicRepos(CONNECTION_STRING);      
        static void Main(string[] args)
        {
            
        }
        static void Menu()
        {
            int answer = -1;
            while (answer != 0)
            {
                Console.WriteLine("1.Показать текущие ремонты");
                Console.WriteLine("0.Выход");
                switch (answer)
                {
                    case 1:
                        ActualService();
                        break;
                    case 0:
                        Console.ReadLine();
                        break;
                }
            }
        }
        private static void ActualService()
        {
            using(var connection = new SqlConnection())
            {
                
            }
        }
    }
}
