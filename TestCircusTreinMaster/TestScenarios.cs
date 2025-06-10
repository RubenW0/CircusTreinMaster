using CircusTreinMaster;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCircusTreinMaster
{
    [TestClass]
    public class TestScenarios
    {
        [TestMethod]
        public void NumberOfWagonsScenario1()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(2, train.GetWagonCount(), "Expected 2 wagons.");
            Assert.AreEqual(6, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario2()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(2, train.GetWagonCount(), "Expected 2 wagons.");
            Assert.AreEqual(9, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario3()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(4, train.GetWagonCount(), "Expected 4 wagons.");
            Assert.AreEqual(10, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario4()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(5, train.GetWagonCount(), "Expected 5 wagons.");
            Assert.AreEqual(11, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario5()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Small)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(2, train.GetWagonCount(), "Expected 2 wagons.");
            Assert.AreEqual(5, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario6()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(3, train.GetWagonCount(), "Expected 3 wagons.");
            Assert.AreEqual(8, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario7()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Large),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Carnivore, Animal.Size.Small),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(11, train.GetWagonCount(), "Expected 11 wagons.");
            Assert.AreEqual(18, train.GetTotalAnimalCount(), "All animals must be placed.");
        }

        [TestMethod]
        public void NumberOfWagonsScenarioExperimentalWagons()
        {
            // Arrange
            var train = new Train();
            var animals = new[]
            {
                new Animal(Animal.Diet.Carnivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium),
                new Animal(Animal.Diet.Herbivore, Animal.Size.Medium)
            };
            train.animals.AddRange(animals);

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.AreEqual(2, train.GetWagonCount(), "Expected 2 wagons using experimental logic.");
            Assert.AreEqual(5, train.GetTotalAnimalCount(), "All animals must be placed.");
        }
    }
}
