using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircusTreinMaster;

namespace Circustrein
{
    internal class Program
    {
        public static List<Animal> animals;
        public static Train train = new Train();

        static void Main()
        {
            animals = new List<Animal>();

            //train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            //train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            //train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));

            //train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            //train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));

            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium)); 
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)); 
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)); 
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)); 
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));


            train.SortAnimals();
            PrintSortedAnimals(train);
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();
            PrintDistribution(train);
        }

        public static void PrintSortedAnimals(Train train)
        {
            Console.WriteLine("Animals Ascending (Carnivores and Herbivores Small to Large):");
            foreach (var animal in train.animalsAscending)
            {
                Console.WriteLine($"Diet: {animal.GetDiet()}, Size: {animal.GetSize()}");
            }

            Console.WriteLine("\nAnimals Descending (Carnivores Small to Large, Herbivores Large to Small):");
            foreach (var animal in train.animalsDescending)
            {
                Console.WriteLine($"Diet: {animal.GetDiet()}, Size: {animal.GetSize()}");
            }
        }

        public static void PrintDistribution(Train train)
        {
            var wagons = train.GetWagons();
            for (int i = 0; i < wagons.Count(); i++)
            {
                string wagonType = wagons[i] is ExperimentalWagon ? "Experimental" : "Regular";

                Console.WriteLine($"Wagon {i + 1} ({wagonType}):");

                foreach (var animal in wagons[i].GetAnimals())
                {
                    Console.WriteLine($"- {animal.GetDiet()} {animal.GetSize()}");
                }

                Console.WriteLine();
            }
        }

    }
}
