using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTreinMaster
{
    public class Pair
    {
        public Animal FirstAnimal { get; set; }
        public Animal SecondAnimal { get; set; }

        public Pair(Animal first, Animal second)
        {
            FirstAnimal = first;
            SecondAnimal = second;
        }
    }
}
