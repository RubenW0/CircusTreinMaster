using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTreinMaster
{
    public class Animal
    {
        public enum Diet
        {
            Herbivore,
            Carnivore

        }

        public enum Size
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        private Diet AnimalDiet { get; set; }
        private Size AnimalSize { get; set; }

        public Animal(Diet diet, Size size)
        {
            AnimalDiet = diet;
            AnimalSize = size;
        }

        public Diet GetDiet()
        {
            return AnimalDiet;
        }

        public Size GetSize()
        {
            return AnimalSize;
        }

        public int GetPoints()
        {
            return (int)AnimalSize;
        }

        public bool CanCoexistWith(Animal otherAnimal)
        {
            if (this.AnimalDiet == Diet.Carnivore && (int)this.AnimalSize >= (int)otherAnimal.AnimalSize)
            {
                return false;
            }

            if (otherAnimal.AnimalDiet == Diet.Carnivore && (int)otherAnimal.AnimalSize >= (int)this.AnimalSize)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return GetSize().ToString() + "-" + GetDiet().ToString();
        }
    }
}

