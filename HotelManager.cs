using System.Collections.Generic;

namespace KrisiTediPraktika10g
{
    internal class HotelManager
    {
        internal static readonly IEnumerable<object> rooms;
        private string filePath;

        public HotelManager(string filePath)
        {
            this.filePath = filePath;
        }
    }
}