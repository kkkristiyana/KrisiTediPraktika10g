using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiTediPraktika10g
{
    public class Hotel
    {
        private int roomNumber;
        private string type;
        private int capacity;

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            private set
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
            private set
            {
                if (type=="")
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
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Капацитетът на стаюта трябва да е по-голям от 0!");
                }
                else
                {
                    capacity = value;
                }
            }
        }
    }
}
