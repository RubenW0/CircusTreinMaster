using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTreinMaster
{
    public class Train
    {
        private List<Wagon> wagonList;
        public List<Animal> animals;
        public List<Animal> animalsAscending;
        public List<Animal> animalsDescending;

        private int experimentalWagonCount = 0;
        private const int MaxExperimentalWagons = 4;

        public Train()
        {
            wagonList = new List<Wagon>();
            animals = new List<Animal>();
            animalsAscending = new List<Animal>();
            animalsDescending = new List<Animal>();
        }

        public List<Wagon> GetWagons()
        {
            return wagonList;
        }


        public void SortAnimals()
        {
            // Ascending list:
            animalsAscending = animals
                .OrderBy(a => a.GetSize())  // Small to large by size
                .ThenBy(a => a.GetDiet() == Animal.Diet.Carnivore ? 0 : 1) // Carnivores first
                .ToList();

            // Descending list:
            animalsDescending = animals
                .OrderBy(a => a.GetDiet() == Animal.Diet.Carnivore ? 0 : 1) // Carnivores first
                .ThenBy(a => a.GetDiet() == Animal.Diet.Carnivore
                    ? (int)a.GetSize()  // Carnivores: small to large
                    : -(int)a.GetSize())  // Herbivores: large to small
                .ToList();
        }


        public void PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient()
        {


            if (PlaceAnimalsInWagons(animalsAscending) <= PlaceAnimalsInWagons(animalsDescending))
            {
                PlaceAnimalsInWagons(animalsAscending);
            }
            else
            {
                PlaceAnimalsInWagons(animalsDescending);
            }
        }
        private int PlaceAnimalsInWagons(List<Animal> animals)
        {
            wagonList.Clear();
            experimentalWagonCount = 0;

            foreach (var animal in animals)
            {
                if (!TryToAddAnimalToExistingWagons(animal))
                {
                    AddAnimalToNewWagon(animal);
                }
            }
            return wagonList.Count;
        }

        private void AddAnimalToNewWagon(Animal animal)
        {
            Wagon wagon;
            if (experimentalWagonCount < MaxExperimentalWagons && animal.GetSize() != Animal.Size.Large)
            {
                wagon = new ExperimentalWagon();
                experimentalWagonCount++;
            }
            else
            {
                wagon = new Wagon();
            }

            if (wagon.CanAddAnimal(animal))
            {
                wagon.AddAnimal(animal);
                wagonList.Add(wagon);
            }
        }

        private bool TryToAddAnimalToExistingWagons(Animal animal)
        {
            // Try to add to experimental wagons first
            foreach (var wagon in wagonList.OfType<ExperimentalWagon>())
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal); 
                    return true;
                }
            }

            // Then try to add to regular wagons
            foreach (var wagon in wagonList.Where(w => !(w is ExperimentalWagon)))
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal); 
                    return true;
                }
            }

            // If no existing wagon can take the animal, create a new one
            if (experimentalWagonCount < MaxExperimentalWagons && animal.GetSize() != Animal.Size.Large)
            {
                var newExpWagon = new ExperimentalWagon();
                if (newExpWagon.CanAddAnimal(animal))
                {
                    newExpWagon.AddAnimal(animal);
                    wagonList.Add(newExpWagon);
                    experimentalWagonCount++;
                    return true;
                }
            }

            return false;
        }

        public int GetWagonCount()
        {
            return wagonList.Count;
        }

    }
}
