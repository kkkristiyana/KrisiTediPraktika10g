using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiTediPraktika10g
{
    public class Room
    {
        private int roomNumber;
        private string type;
        private int capacity;
        private bool occupied;
        private double pricePerNight;
        private string guestName;

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Номерът на стаята трябва да е положителен и по-голям от 0!");
                }
                else
                {
                    roomNumber = value;
                }
            }
        }
        public string Type 
        {    
            get
            {
                return type;
            }
            set
            {
                if (type==" ")
                {
                    throw new ArgumentException("Полето с типа на стаята не може да е празно!");
                }
                else
                {
                    type = value;
                }
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Капацитетът на стаюта трябва да е по-голям от 0!");
                }
                else if (value>4)
                {
                    throw new ArgumentException("Максималният капацитет е четири човека в стая!");
                }
                else
                {
                    capacity = value;
                }
            }
        }

        public bool Occupied
        {
            get
            {
                return occupied;
            }
            set
            {
                if (occupied!=true)
                {

                }
                occupied = value;
            }
        }

        public double PricePerNight 
        { 
            get
            {
                return pricePerNight;
            }
            set 
            { 
                pricePerNight = value; 
            }
        }

        public string GuestName 
        {
            get
            {
                return guestName;
            }
            set 
            { 
                guestName = value; 
            }
        }
    }
}
