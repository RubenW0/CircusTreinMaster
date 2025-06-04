using CircusTreinMaster;

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
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 2;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 2.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario2()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 2;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 2.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario3()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 4;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 4.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario4()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 5;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 5.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario5()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 2;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 2.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario6()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 3;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 3.");
        }

        [TestMethod]
        public void NumberOfWagonsScenario7()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 11;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 11.");
        }

        [TestMethod]
        public void NumberOfWagonsScenarioExperimentalWagons() 
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expectedWagonCount = 2;
            Assert.AreEqual(expectedWagonCount, train.GetWagonCount(), "The number of wagons should be 2.");
        }

    }
}