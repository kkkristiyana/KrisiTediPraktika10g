﻿using System;
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
            string path = "../../RoomInfo.txt";
            var lines = new List<string>();
            Console.WriteLine("Въведете номер на стаята и име:");
            int RoomNumber = int.Parse(Console.ReadLine());
            
            while (RoomNumber<=0)
            {
                Console.WriteLine("Номера на стаята трябва да бъде по голям от 0!");
                Console.WriteLine("Въведете номера на стаята:");
                RoomNumber = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Въведете име:");
            string guestname = Console.ReadLine();

            foreach (var room in rooms)
            {
                if (!room.Occupied)
                {
                    Console.WriteLine($"Room {room.RoomNumber} ({room.Type}), Price per night: {room.PricePerNight}");
                }
            }
            foreach (var room in rooms)
            {
                if (room.Occupied)
                {
                    Console.WriteLine($"Room {room.RoomNumber} ({room.Type}), Guest: {room.GuestName}");
                }
            }
            File.WriteAllLines(path, lines);
        }

        private static void CheckRoomsPriceandAvailability()
        {
            
            var lines = new List<string>();
            Console.WriteLine("Въведи номер и тип на стаята:");
            int RoomNumber = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            while (RoomNumber <= 0)
            {
                Console.WriteLine("Номера на стаята трябва да бъде по голям от 0!");
                Console.WriteLine("Въведете номера на стаята:");
            }
            Console.WriteLine("Въведи тип на стаята:");
            type = Console.ReadLine();
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

        private static void showActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
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
                else if (option == "4")
                {
                    ReferenceForRoom();
                }
                else if (option == "5")
                {
                    Exit();
                }
            }
  
        }

        



         public static void RezerviraneNaStaq()
         {
             Console.WriteLine("Въведете номер на стаята: ");
             int roomNum = int.Parse(Console.ReadLine());
            while (roomNum<=0)
            {
                Console.WriteLine("Номерът на стаята трябва да е положителен и по-голям от 0!");
                Console.WriteLine("Въведете номер на стаята: ");
                roomNum =int.Parse(Console.ReadLine());
            }
             Console.WriteLine("Въведете тип на стаята: ");
             string type = Console.ReadLine();
            while (type==null)
            {
                Console.WriteLine("Полето с типа на стаята не може да е празно!");
                Console.WriteLine("Въведете тип на стаята: ");
                type = Console.ReadLine();
            }
             Console.WriteLine("Въведете капацитет на стаята: ");
             int capacity = int.Parse(Console.ReadLine());
            while (capacity!=1&&capacity!=2&&capacity!=3&&capacity!=4)
            {
                Console.WriteLine("Максималният капацитет е четири човека в стая!");
                Console.WriteLine("Въведете капацитет на стаята: ");
                capacity=int.Parse(Console.ReadLine());
            }
             Console.WriteLine("Въведете цена за нощ на стаята: ");
             double pricePn = double.Parse(Console.ReadLine());
            while (pricePn==0)
            {
                Console.WriteLine("Не предлагаме безплатен престой. :)");
                Console.WriteLine("Въведете цена за нощ на стаята: ");
                pricePn=double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Въведете име на госта:");
            string guestName = Console.ReadLine();
            while (guestName=="")
            {
                Console.WriteLine("Моля напишете името си!");
                Console.WriteLine("Въведете име на госта:");
                guestName = Console.ReadLine();
            }
            Console.WriteLine("Маркирайте стаята като свободна(false), за да я запазите!");
            bool occ = bool.Parse(Console.ReadLine());
            if (occ == false)
            {
                occ = true;
            }
            else
            {
                Console.WriteLine("Тази стая е вече резервирана, изберете друга!");
                Console.WriteLine("Въведете свободна стая:");
                occ = bool.Parse(Console.ReadLine());
            }
            Room roomR = new Room(roomNum, type, capacity, pricePn, occ, guestName);
            rooms.Add(roomR);
         }
        public static void ReleaseRoom() 
            //ako se naloji, tova e izgubeniqt mi ReleaseRoom kod.
            //okay girl
        {
            Console.WriteLine("Съжаляваме за неудобството, но ще се наложи да въведете пълните данни от резервирането на стаята. Благодарим за разбирането!");
            Console.WriteLine("Въведете номера на стаята за освобождаване: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете регистрационно име: ");
            string guestName = Console.ReadLine(); 
            Console.WriteLine("Въведете типа на стаята:");
            string type = Console.ReadLine();
            Console.WriteLine("Въведете капацитета и:");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете заетостта и(задължително true):");
            bool occ = bool.Parse(Console.ReadLine());
            Console.WriteLine("Въведете цената за нощувка:");
            double pricePn = double.Parse(Console.ReadLine());
            Room room = new Room(roomNumber, type, capacity, pricePn, occ, guestName);
            if (room.Occupied == true)
            {
                room.Occupied = false;
                room.GuestName = "";
                Console.WriteLine("Стаята е освободена.");

            }
            else
            {
                Console.WriteLine("Регистрация на тази стая не е намерена.");
            }
            rooms.Remove(room);
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

        private static void SaveRoom()
        {
            StreamWriter writer = new StreamWriter(path, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Room room in rooms)
                {
                    writer.WriteLine(room);
                }
            }
        }
        

    }

}
