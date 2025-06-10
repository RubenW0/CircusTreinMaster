using CircusTreinMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCircusTreinMaster
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void CanCoexist_CarnivoreCannotCoexistWithEqualOrSmallerHerbivore()
        {
            // Arrange
            var carnivore = new Animal(Animal.Diet.Carnivore, Animal.Size.Medium);
            var herbivore = new Animal(Animal.Diet.Herbivore, Animal.Size.Small);

            // Act
            bool canCoexist = carnivore.CanCoexistWith(herbivore);

            // Assert
            Assert.IsFalse(canCoexist);
        }

        [TestMethod]
        public void CanCoexist_HerbivoreCannotCoexistWithEqualOrLargerCarnivore()
        {
            // Arrange
            var herbivore = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium);
            var carnivore = new Animal(Animal.Diet.Carnivore, Animal.Size.Medium);

            // Act
            bool canCoexist = herbivore.CanCoexistWith(carnivore);

            // Assert
            Assert.IsFalse(canCoexist);
        }

        [TestMethod]
        public void CanCoexist_HerbivoresCanCoexistWithEachOther()
        {
            // Arrange
            var herbivore1 = new Animal(Animal.Diet.Herbivore, Animal.Size.Small);
            var herbivore2 = new Animal(Animal.Diet.Herbivore, Animal.Size.Large);

            // Act
            bool canCoexist = herbivore1.CanCoexistWith(herbivore2);

            // Assert
            Assert.IsTrue(canCoexist);
        }

        [TestMethod]
        public void GetPoints_ReturnsCorrectSizeValue()
        {
            // Arrange
            var smallAnimal = new Animal(Animal.Diet.Herbivore, Animal.Size.Small);
            var mediumAnimal = new Animal(Animal.Diet.Herbivore, Animal.Size.Medium);
            var largeAnimal = new Animal(Animal.Diet.Herbivore, Animal.Size.Large);

            // Act & Assert
            Assert.AreEqual(1, smallAnimal.GetPoints());
            Assert.AreEqual(3, mediumAnimal.GetPoints());
            Assert.AreEqual(5, largeAnimal.GetPoints());
        }
    }
}