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
            List<Animal> animalsAscCopy = new List<Animal>(animalsAscending);
            List<Animal> animalsDescCopy = new List<Animal>(animalsDescending);

            List<Wagon> wagonsAscExperimental = TryPlacingAnimals(animalsAscCopy);
            List<Wagon> wagonsDescExperimental = TryPlacingAnimals(animalsDescCopy);

            List<Wagon> wagonsAscRegular = PlaceAnimalsInRegularWagonsOnly(animalsAscending);
            List<Wagon> wagonsDescRegular = PlaceAnimalsInRegularWagonsOnly(animalsDescending);

            List<Wagon> bestExperimental;
            if (wagonsAscExperimental.Count <= wagonsDescExperimental.Count)
            {
                bestExperimental = wagonsAscExperimental;
            }
            else
            {
                bestExperimental = wagonsDescExperimental;
            }

            List<Wagon> bestRegular;
            if (wagonsAscRegular.Count <= wagonsDescRegular.Count)
            {
                bestRegular = wagonsAscRegular;
            }
            else
            {
                bestRegular = wagonsDescRegular;
            }

            if (bestExperimental.Count < bestRegular.Count)
            {
                wagonList = bestExperimental;
            }
            else
            {
                wagonList = bestRegular;
            }
        }

        private List<Wagon> PlaceAnimalsInRegularWagonsOnly(List<Animal> animalList)
        {
            var wagons = new List<Wagon>();

            foreach (var animal in animalList)
            {
                Wagon bestWagon = null;
                int bestFreePointsAfter = int.MaxValue;

                foreach (var wagon in wagons.Where(w => !(w is ExperimentalWagon)))
                {
                    if (wagon.CanAddAnimal(animal))
                    {
                        int freeAfter = wagon.GetFreePoints() - animal.GetPoints();
                        if (freeAfter < bestFreePointsAfter)
                        {
                            bestWagon = wagon;
                            bestFreePointsAfter = freeAfter;
                        }
                    }
                }

                if (bestWagon == null)
                {
                    Wagon newWagon = new Wagon();
                    newWagon.AddAnimal(animal);
                    wagons.Add(newWagon);
                }
                else
                {
                    bestWagon.AddAnimal(animal);
                }
            }

            return wagons;
        }


        private List<Wagon> TryPlacingAnimals(List<Animal> animalList)
        {
            List<Wagon> wagons = new List<Wagon>();
            int experimentalCount = 0;

            List<Pair> pairs = FindPairsForExperimentalWagons(animalList);

            foreach (Pair pair in pairs)
            {
                if (experimentalCount < MaxExperimentalWagons)
                {
                    ExperimentalWagon expWagon = new ExperimentalWagon();
                    expWagon.AddAnimal(pair.FirstAnimal);
                    expWagon.AddAnimal(pair.SecondAnimal);
                    wagons.Add(expWagon);
                    experimentalCount++;

                    animalList.Remove(pair.FirstAnimal);
                    animalList.Remove(pair.SecondAnimal);
                }
            }

            foreach (Animal animal in animalList)
            {
                Wagon bestWagon = FindBestExistingWagon(wagons, animal);
                if (bestWagon == null)
                {
                    Wagon newWagon = new Wagon();
                    newWagon.AddAnimal(animal);
                    wagons.Add(newWagon);
                }
                else
                {
                    bestWagon.AddAnimal(animal);
                }
            }

            return wagons;
        }

        private List<Pair> FindPairsForExperimentalWagons(List<Animal> animalList)
        {
            List<Pair> pairs = new List<Pair>();
            List<int> pairedAnimals = new List<int>();

            for (int i = 0; i < animalList.Count; i++)
            {
                if (pairedAnimals.Contains(i))
                    continue;

                Animal a = animalList[i];

                if (a.GetSize() == Animal.Size.Large)
                    continue;

                for (int j = i + 1; j < animalList.Count; j++)
                {
                    if (pairedAnimals.Contains(j))
                        continue;

                    Animal b = animalList[j];

                    if (b.GetSize() == Animal.Size.Large)
                        continue;

                    if (a.GetDiet() == Animal.Diet.Carnivore && b.GetDiet() == Animal.Diet.Carnivore)
                    {
                        pairs.Add(new Pair(a, b));
                        pairedAnimals.Add(i);
                        pairedAnimals.Add(j);
                        break;
                    }
 
                    if ((a.GetDiet() == Animal.Diet.Carnivore && b.GetDiet() == Animal.Diet.Herbivore) ||
                        (a.GetDiet() == Animal.Diet.Herbivore && b.GetDiet() == Animal.Diet.Carnivore))
                    {
                        pairs.Add(new Pair(a, b));
                        pairedAnimals.Add(i);
                        pairedAnimals.Add(j);
                        break;
                    }
                }
            }

            return pairs;
        }

        private Wagon FindBestExistingWagon(List<Wagon> wagons, Animal animal)
        {
            Wagon bestWagon = null;
            int bestFreePointsAfter = int.MaxValue;

            foreach (var wagon in wagons.OrderBy(w => w is ExperimentalWagon)) 
            {
                if (wagon.CanAddAnimal(animal))
                {
                    int freeAfter = wagon.GetFreePoints() - animal.GetPoints();
                    if (freeAfter < bestFreePointsAfter)
                    {
                        bestWagon = wagon;
                        bestFreePointsAfter = freeAfter;
                    }
                }
            }

            return bestWagon;
        }


        // for testing purposes
        public int GetWagonCount()
        {
            return wagonList.Count;
        }

        public int GetTotalAnimalCount()
        {
            return wagonList.SelectMany(w => w.GetAnimals()).Count(); 
        }

    }
}
