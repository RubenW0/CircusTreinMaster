using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTreinMaster
{
    public class ExperimentalWagon : Wagon
    {
        public override bool CanAddAnimal(Animal animal)
        {
            if (GetTotalPoints() + animal.GetPoints() > 10)
                return false;

            if (animalsInWagon.Count >= 2)
                return false;

            if (animal.GetSize() == Animal.Size.Large)
                return false;

            if (animalsInWagon.Count == 1)
            {
                var existing = animalsInWagon[0];
                if ((existing.GetDiet() == Animal.Diet.Carnivore && animal.GetDiet() == Animal.Diet.Carnivore) ||
                    (existing.GetDiet() != animal.GetDiet()))
                {
                    return true; 
                }
                return false;
            }

            return true;
        }

    }
}
