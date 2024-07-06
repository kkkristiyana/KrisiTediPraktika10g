using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiTediPraktika10g
{
    class Program
    {
 
        private static List<Room> rooms = new List<Room>();
        private static string menuActionChoice;
        static void Main(string[] args)
        {
            
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string filePath = "rooms.txt"; 
            var hotelManager = new HotelManager(filePath);

            ShowMenu();
            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        showActionTitle("Резервирай стая");
                        ReserveRoom();
                        break;

                    case "2":
                        showActionTitle("Освободи стая");
                        FreeRoom();
                        break;

                    case "3":
                        showActionTitle("Проверка за наличност и цена на стая");
                        CheckRoomsPriceandAvailability();
                        break;

                    case "4":
                        showActionTitle("Справка за заетите стаи и техните гости");
                        ReferenceForRoom();
                        break;
                    case "x":
                        Exit();
                        break;
                    default:
                        // todo: implement default case

                        break;
                }
            }
        }

        private static void RoomOptions()
        {
            throw new NotImplementedException();
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ReferenceForRoom()
        {
            throw new NotImplementedException();
        }

        private static void CheckRoomsPriceandAvailability()
        {
            throw new NotImplementedException();
        }

        private static void FreeRoom()
        {
            throw new NotImplementedException();
        }

        private static void showActionTitle(string v)
        {
            throw new NotImplementedException();
        }

        public static void ReserveRoom()
        {
            Console.Write("Номер на стаята: ");
           int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Тип на стаята: ");
            string type = Console.ReadLine();

            Console.Write("Капацитет на стаята: ");
            int capacity = int.Parse(Console.ReadLine());

            Console.Write("Цена на стаята за една нощувка: ");
            int pricePerNight = int.Parse(Console.ReadLine());

            Console.Write("Свободна ли е стаята: ");
            bool occupied = bool.Parse(Console.ReadLine());

            Console.Write("Име на госта: ");
            string guestName = Console.ReadLine();

            try
            {
                Room newRoom = new Room(roomNumber, type, capacity,
                    pricePerNight, occupied, guestName);

                rooms.Add(newRoom);
                //belejkazanapomqne!!
                ShowResultMessage($"Стая с номер {roomNumber} е добавена успешно.");
            }
            catch (Exception)
            {

                ShowResultMessage($"Невалидни данни за полет");
            }
        }

        private static void ShowMenu()
        {
           while (true)
           {
                Console.WriteLine("Hotel Management System");
                Console.WriteLine("1. Списък на всички стаи");
                Console.WriteLine("2. Настаняване на гостите");
                Console.WriteLine("3. Провери гостите");
                Console.WriteLine("4. Exit");
                Console.Write("Избери опция: ");
                var choice = Console.ReadLine();
           }

            
        }


      
       /* public static void LoadRooms()
        {
            Console.WriteLine("Въведете номер на стаята: ");
            int roomNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете тип на стаята: ");
            string type = Console.ReadLine();
            Console.WriteLine("Въведете капацитет на стаята: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете цена за нощ на стаята: ");
            double pricePn = double.Parse(Console.ReadLine());

           
        }*/

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


        /* public int NalichnostNaStai(List<int>nalichni)
         {
             //napravih dvata metoda deto trqbvashe da pravq
             //sushto i tozi deto klasniq mi kaza v chas i mi trqbvaha promenlivite zatova gi slojih
             //davai tedi vqrvam v teb za drugite dve i tam oshte nqkoi neshta imat da se slagat sus tekstoviq fail
             //imashe i edno deto while v maina ahmed beshe slojil, taka che vij i nego

         }*/
        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }
        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }




    }
}
