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
        [DataTestMethod]
        // Herbivore vs Herbivore
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Small, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Medium, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Large, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Small, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Medium, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Large, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Small, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Medium, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Large, true)]

        // Herbivore vs Carnivore
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Large, false)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Small, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Large, false)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Small, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Medium, true)]
        [DataRow(Animal.Diet.Herbivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Large, false)]

        // Carnivore vs Herbivore
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Medium, true)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Herbivore, Animal.Size.Large, true)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Herbivore, Animal.Size.Large, true)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Herbivore, Animal.Size.Large, false)]

        // Carnivore vs Carnivore
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Small, Animal.Diet.Carnivore, Animal.Size.Large, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Medium, Animal.Diet.Carnivore, Animal.Size.Large, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Small, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Medium, false)]
        [DataRow(Animal.Diet.Carnivore, Animal.Size.Large, Animal.Diet.Carnivore, Animal.Size.Large, false)]

        public void CanCoexist_TestAllCombinations(
            Animal.Diet diet1, Animal.Size size1,
            Animal.Diet diet2, Animal.Size size2,
            bool expected)
        {
            // Arrange
            var animal1 = new Animal(diet1, size1);
            var animal2 = new Animal(diet2, size2);

            // Act
            bool result = animal1.CanCoexistWith(animal2);

            // Assert
            Assert.AreEqual(expected, result,
                $"Fout bij combinatie: {animal1} & {animal2}");
        }
    }
}