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
        private const string path = "../../RoomInfo.txt";

        static void Main(string[] args)
        {
            //string path = "../../RoomInfo.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            ShowMenu();
            while (true)
            {
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        showActionTitle("Резервирай стая");
                        RezerviraneNaStaq();
                        break;

                    case "2":
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
                        Console.WriteLine("Невалидна опция, опитайте отново.");
                        break;
                }
            }
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
            var lines = new List<string>();
            
            foreach (var room in rooms)
            {
                lines.Add(item: $"{room.RoomNumber}, {room.Type}, {room.Capacity}, {room.PricePerNight}, {room.Occupied}, {room.GuestName}");
            }
            File.WriteAllLines(path, lines);
        }

        public static void FreeRoom()
        {
            Console.WriteLine("Номер на стаята:");
            int roomNum = int.Parse(Console.ReadLine());
            bool Found = false;
            string path = "../../RoomInfo.txt";
            var lines = File.ReadAllLines(path).ToList();


            
            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int number) && number == roomNum)
                {
                    lines[i] = $"{roomNum},Свободна";
                    Found = true;
                    break;
                }
            }
            if (!Found)
            {
                Console.WriteLine("Стаята не е намерена.");
                return;
            }
            File.WriteAllLines(path, lines);

            Console.WriteLine($"Стаята {roomNum} сега е маркирана като запазена.");
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
            bool occ = true;
            Console.Write("Име на госта: ");
            string guestName = Console.ReadLine();
            if (occ == false)
            {

                Console.WriteLine("Свободна е!");
                 
            }
            else
            {
                Console.WriteLine("Тази стая е вече резервирана, изберете друга!");

            }

           
           /* try
            {
                Room newRoom = new Room(roomNumber, type, capacity,
                    pricePerNight, occupied, guestName);

                rooms.Add(newRoom);
                //belejkazanapomqne!!
                ShowResultMessage($"Стая с номер {roomNumber} е добавена успешно.");
            }
            catch (Exception)
            {

                ShowResultMessage($"");
            }*/

        }

        private static void ShowMenu()
        {
           while (true)
           {
                Console.Clear();

                AddLine();
                Console.WriteLine("М Е Н Ю");
                AddLine();
                Console.WriteLine("Моля изберете желаното действие:");
                AddLine();
                Console.WriteLine("1: Резервирай стая");
                Console.WriteLine("2: Освободи стая");
                Console.WriteLine("3: Проверка за наличност и цена на стая");
                Console.WriteLine("4: Справка за заетите стаи и техните гости");
                Console.WriteLine("x: Изход от програмата");
                AddLine();
                Console.Write("Вашият избор: ");
                var option = Console.ReadLine();
                if (option == "1")
                {
                    RezerviraneNaStaq();
                }
                else if (option == "2")
                {
                    FreeRoom();
                }
                else if (option == "3")
                {
                    CheckRoomsPriceandAvailability();
                }
            }
  
        }

        



         public static void RezerviraneNaStaq()
         {
             Console.WriteLine("Въведете номер на стаята: ");
             int roomNum = int.Parse(Console.ReadLine());
             Console.WriteLine("Въведете тип на стаята: ");
             string type = Console.ReadLine();
             Console.WriteLine("Въведете капацитет на стаята: ");
             int capacity = int.Parse(Console.ReadLine());
             Console.WriteLine("Въведете цена за нощ на стаята: ");
             double pricePn = double.Parse(Console.ReadLine());
            Console.WriteLine("Маркирайте стаята като свободна(false), за да я запазите!");
            bool occ = bool.Parse(Console.ReadLine());
            if (occ == false)
            {
                occ = true;
            }
            else
            {
                throw new ArgumentException("Тази стая е вече резервирана, изберете друга!");
            }
        }
                 

         /*public int NalichnostNaStai(List<int>nalichni)
         {
             //napravih dvata metoda deto trqbvashe da pravq
             //sushto i tozi deto klasniq mi kaza v chas i mi trqbvaha promenlivite zatova gi slojih
             //davai tedi vqrvam v teb za drugite dve i tam oshte nqkoi neshta imat da se slagat sus tekstoviq fail
             //imashe i edno deto while v maina gospodin ahmed beshe slojil, taka che vij i nego

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
