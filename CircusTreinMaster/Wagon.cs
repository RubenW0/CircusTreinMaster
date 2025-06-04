using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTreinMaster
{
    public class Wagon
    {
        public List<Animal> animalsInWagon;

        public Wagon()
        {
            animalsInWagon = new List<Animal>();
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            return animalsInWagon as IReadOnlyList<Animal>;
        }

        public int GetTotalPoints()
        {
            int totalPoints = 0;
            foreach (var animal in animalsInWagon)
            {
                totalPoints += animal.GetPoints();
            }
            return totalPoints;
        }

        public virtual bool CanAddAnimal(Animal animal)
        {
            if (GetTotalPoints() + animal.GetPoints() > 10)
            {
                return false;
            }

            foreach (var existingAnimal in animalsInWagon)
            {
                if (!animal.CanCoexistWith(existingAnimal))
                {
                    return false;
                }
            }

            return true; 
        }

        public void AddAnimal(Animal animal)
        {
            animalsInWagon.Add(animal);
        }

        public int GetFreePoints()
        {
            return 10 - GetTotalPoints();
        }

    }
}
