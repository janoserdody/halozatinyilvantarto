using Moq;
using NUnit.Framework;
using BusinessLayer.DrawingModule;
using BusinessLayer.DrawingModule._interfaces;
using System.Collections.Generic;

namespace Test.BusinessLayer
{
    [TestFixture]
    class DijkstraTests
    {
        [Test]
        public void FindTheShortestRoute_ReturnList()
        {
            // Arrange
            int[,] graph = new int[,]
            {
                {0, 1, 0, 0, 0},
                {1, 0, 1, 0, 0},
                {0, 1, 0, 0, 1},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0}
            };

            IDijkstra testObject = new Dijkstra();

            // Act
            List<int> result = testObject.DijkstraAlg(graph, 1, 4);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(4));
        }
    }
}
