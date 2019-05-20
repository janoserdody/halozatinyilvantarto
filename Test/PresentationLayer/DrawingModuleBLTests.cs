using Moq;
using NUnit.Framework;
using Common.Interfaces;
using Common.Models;
using BusinessLayer.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using PresentationLayer.DrawingModule;

namespace Test.PresentationLayer
{
    [TestFixture]
    class DrawingModuleBLTests
    {
        [Test]
        public void When_Drawing_Then_CallsPrintPath_PrintMethod()
        {
            // Arrange
            IConnection connection1 = GetConnection(2 , 1);
            IConnection connection2 = GetConnection(3, 2);
            IConnection connection3 = GetConnection(5, 3);
            IConnection connection4 = GetConnection(4, 2);

            Mock<IFrameWork> frameWorkMock = GetFrameWork();
            frameWorkMock.Setup(item => item.ItemActiveCount).Returns(4);
            frameWorkMock.Setup(c => c.GetConnection(1)).Returns(connection1);
            frameWorkMock.Setup(c => c.GetConnection(2)).Returns(connection2);
            frameWorkMock.Setup(c => c.GetConnection(3)).Returns(connection3);
            frameWorkMock.Setup(c => c.GetConnection(4)).Returns(connection4);

            Mock<IPrintPath> printPathMock = GetPrintPath();
            IDrawingModuleBL testObject = new DrawingModuleBL(
                frameWorkMock.Object,
                printPathMock.Object);

            // Act
            testObject.Drawing(1, 4);

            // Assert
            printPathMock.Verify(path => path.Print(It.IsAny<int[,]>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        private IConnection GetConnection(int destination, int source)
        {
            return new Connection() {DestinationItemId = destination, SourceItemId = source};
        }

        private Mock<IPrintPath> GetPrintPath()
        {
            return new Mock<IPrintPath>();
        }

        private Mock<IFrameWork> GetFrameWork()
        {
            return new Mock<IFrameWork>();
        }
    }
}
