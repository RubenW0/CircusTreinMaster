using CircusTreinMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCircusTreinMaster
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void SortAnimals_CarnivoresFirstThenSizeSorting()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Small));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Large));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));

            // Act
            train.SortAnimals();

            // Assert
            Assert.AreEqual("Small-Carnivore", train.animalsDescending[0].ToString());
            Assert.AreEqual("Medium-Carnivore", train.animalsDescending[1].ToString());
            Assert.AreEqual("Large-Herbivore", train.animalsDescending[2].ToString());
            Assert.AreEqual("Small-Herbivore", train.animalsDescending[3].ToString());
        }

        [TestMethod]
        public void PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient_UsesMinimalWagons()
        {
            // Arrange
            var train = new Train();
            train.animals.AddRange(new List<Animal>
        {
            new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
            new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
            new Animal(Animal.Diet.Herbivore, Animal.Size.Small),
            new Animal(Animal.Diet.Carnivore, Animal.Size.Small)
        });

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int wagonCount = train.GetWagonCount();
            Assert.IsTrue(wagonCount > 0 && wagonCount <= 4);
        }

        [TestMethod]
        public void PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient_ChoosesRegularIfMoreEfficient()
        {
            // Arrange
            var train = new Train();
            train.animals.AddRange(Enumerable.Range(0, 10).Select(_ =>
                new Animal(Animal.Diet.Herbivore, Animal.Size.Large)));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            Assert.IsTrue(train.GetWagons().All(w => w is Wagon && !(w is ExperimentalWagon)));
        }

        [TestMethod]
        public void ExperimentalWagonLimit_IsMaxFour()
        {
            // Arrange
            var train = new Train();
            for (int i = 0; i < 10; i++)
            {
                train.animals.Add(new Animal(i % 2 == 0 ? Animal.Diet.Carnivore : Animal.Diet.Herbivore, Animal.Size.Medium));
            }

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int expCount = train.GetWagons().Count(w => w is ExperimentalWagon);
            Assert.IsTrue(expCount <= 4);
        }

        [TestMethod]
        public void GetWagonCount_ReturnsCorrectCount()
        {
            // Arrange
            var train = new Train();
            train.animals.Add(new Animal(Animal.Diet.Herbivore, Animal.Size.Medium));
            train.animals.Add(new Animal(Animal.Diet.Carnivore, Animal.Size.Small));

            // Act
            train.SortAnimals();
            train.PlaceAnimalsInWagonsByOrderAndChooseTheMostEfficient();

            // Assert
            int count = train.GetWagonCount();
            Assert.AreEqual(train.GetWagons().Count, count);
        }
    }
}
