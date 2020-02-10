using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;
using TheWeddingShop.TechnicalTest.MarsRover.Rovers;

namespace TheWeddingShop.TechnicalTest.MarsRover.UnitTest.Rovers
{
    /// <summary>
    /// Explanation:
    /// Add an example of how to Unit testing against the implemeneted logic of movement of Rover.
    /// 1) Use Moq to Mock the imterface of IArea, and setup the default Plataue value to return.
    /// 2) Use MsTest for the Unit Testing.
    /// 3) Use DataRow for seting up the scenario testing
    /// </summary>
    [TestClass]
    public class RoverTests
    {

        private Mock<IArea> _mockArea;

        [TestInitialize]
        public void SetUp()
        {
            _mockArea = new Mock<IArea>();
        }

        [DataTestMethod]
        [DataRow(1, 2, Direction.E)]
        [DataRow(3, 4, Direction.S)]
        public void Given_valid_deploy_point_and_direction_exposes_as_properties(int expectedX, int expectedY, Direction expectedDirection)
        {
            var rover = new Rover(expectedX, expectedY, expectedDirection, _mockArea.Object);
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
            Assert.AreEqual(expectedDirection, rover.Direction);
        }


        [TestMethod]
        [DataRow(1, 1, Direction.S, Movement.R, Movement.R, Movement.M, 1, 2, Direction.N)]
        [DataRow(2, 4, Direction.E, Movement.M, Movement.M, Movement.M, 5, 4, Direction.E)]
        [DataRow(2, 2, Direction.W, Movement.L, Movement.M, Movement.M, 2, 0, Direction.S)]
        [DataRow(4, 5, Direction.N, Movement.L, Movement.L, Movement.L, 4, 5, Direction.E)]
        [DataRow(0, 0, Direction.S, Movement.L, Movement.M, Movement.M, 2, 0, Direction.E)]
        public void Alters_position_and_direction_in_response_to_movement_list(int startX, int startY,
                Direction startDirection, Movement firstMove, Movement secondMove, Movement thirdMove,
                int expectedX, int expectedY, Direction expectedDirection)
        {
            // Arrange 

            _mockArea.Setup(c => c.GetSize()).Returns(new Size(5, 5));
            var movements = new List<Movement> { firstMove, secondMove, thirdMove };
            var rover = new Rover(startX, startY, startDirection, _mockArea.Object);

            // Act
            rover.Move(movements);

            // Assert
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
            Assert.AreEqual(expectedDirection, rover.Direction);
        }
    }
}
