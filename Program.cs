using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiTediPraktika10g
{
    class Program
    {
        private static List<Room> room = new List<Room>();
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();

            while (true) 
            {
            }
        }

        private static void PrintMenu()
        {
            throw new NotImplementedException();
        }

        public static void LoadRooms()
        {

        }
        public static void Rezervation(int num, string type, int capacity, double price, bool occ, string nameG)
        {
            if (occ == false)
            {
                occ = true;
            }
            else
            {
                throw new ArgumentException("Тази стая е вече резервирана, изберете друга!");
            }
        }
       /* public static void OsvobojdavaneNaStaq(int num)
        {
            Room occupied = new Hotel(occupied);
            if (occupied == true)
            {

            }
        }
        public int NalichnostNaStai(List<int>nalichni)
        {

        }*/
    }
}
