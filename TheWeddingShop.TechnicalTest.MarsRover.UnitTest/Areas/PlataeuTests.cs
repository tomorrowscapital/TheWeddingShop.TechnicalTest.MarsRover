using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;

namespace TheWeddingShop.TechnicalTest.MarsRover.UnitTest.Areas
{
    /// <summary>
    /// Explanation:
    /// Add an example of how to Unit testing of the logic within the object of Plateau.
    /// </summary>
    [TestClass]
    class PlataeuTests
    {

        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(4, 5)]
        public void When_size_has_been_set_returns_size_with_same_values(int expectedWidth, int expectedHeight)
        {
            var expectedSize = new Size(expectedWidth, expectedHeight);
            var plateau = new Plateau();

            plateau.Define(expectedWidth, expectedHeight);
            var actualSize = plateau.GetSize();

            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}
