using CircusTreinMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCircusTreinMaster
{
    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void CanAddAnimal_RejectsAnimalWhenPointLimitExceeded()
        {
            // Arrange
            var wagon = new Wagon();
            var large = new Animal(Animal.Diet.Herbivore, Animal.Size.Large); // 5
            var medium = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium); // 3
            var medium2 = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium); // 3

            // Act
            wagon.AddAnimal(large);
            wagon.AddAnimal(medium);
            bool result = wagon.CanAddAnimal(medium2); // would total 11 points

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddAnimal_ReturnsFalseIfCarnivoreConflict()
        {
            // Arrange
            var wagon = new Wagon();
            var herbivore = new Animal(Animal.Diet.Herbivore, Animal.Size.Small);
            var carnivore = new Animal(Animal.Diet.Carnivore, Animal.Size.Medium);

            // Act
            wagon.AddAnimal(herbivore);
            bool result = wagon.CanAddAnimal(carnivore);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddAnimal_ReturnsTrueIfSafeAndWithinPoints()
        {
            // Arrange
            var wagon = new Wagon();
            var herbivore1 = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium);
            var herbivore2 = new Animal(Animal.Diet.Herbivore, Animal.Size.Small);

            // Act
            bool canAdd1 = wagon.CanAddAnimal(herbivore1);
            wagon.AddAnimal(herbivore1);
            bool canAdd2 = wagon.CanAddAnimal(herbivore2);

            // Assert
            Assert.IsTrue(canAdd1);
            Assert.IsTrue(canAdd2);
        }

        [TestMethod]
        public void GetFreePoints_ReturnsCorrectRemainingPoints()
        {
            // Arrange
            var wagon = new Wagon();
            var animal = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium); // 3 points

            // Act
            wagon.AddAnimal(animal);
            int freePoints = wagon.GetFreePoints();

            // Assert
            Assert.AreEqual(7, freePoints);
        }
    }
}
