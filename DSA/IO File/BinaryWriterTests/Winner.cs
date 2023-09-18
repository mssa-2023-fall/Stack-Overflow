using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWriterTests
{
    internal class Winner
    {
        public int Index { get; set; }
        public int Year { get; set; }
        public int Age { get; set;  }
        public string Name { get; set; }
        public string Movie { get; set; }

        public Winner(string input)
        {
            // "Index", "Year", "Age", "Name", "Movie"
            //1, 1928, 44, "Emil Jannings", "The Last Command, The Way of All Flesh"
            //Index = new String(input[0..input.IndexOf(', ')]));
            string[] helper = input.Split(", ");
            Index = int.Parse(helper[0]);
            Year = int.Parse(helper[1]);
            Age = int.Parse(helper[2]);
            Name = helper[3][1..(helper[3].Length -1)];
            Movie = "";
            for(int i = 4 ; i < helper.Length; i++)
            {
                Movie += helper[i];
                if (helper.Length - 1 > i) Movie += ", ";
            }
            //removing quotes
            Movie = Movie[1..(Movie.Length - 1)];
        }
    }
}
