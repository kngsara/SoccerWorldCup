using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.Models
{
    public class PlayerImage
    {
        private const char DELIMITER = '|';
        public string Name { get; set; }
        public int ShirtNumber { get; set; }
        public string ImagePath { get; set; }


        //build a string for writing
        private string FormatForFileLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(DELIMITER);
            sb.Append(ShirtNumber);
            sb.Append(DELIMITER);
            sb.Append(ImagePath);
            
            return sb.ToString();
        }

        //parse
        private static PlayerImage ParseFromFileLine(string line)
        {
            string[] parts = line.Split(DELIMITER);
            return new PlayerImage
            {
                Name = parts[0],
                ShirtNumber = int.Parse(parts[1]),
                ImagePath = parts[2]
            };
        }
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ShirtNumber);
        }
    }
}
