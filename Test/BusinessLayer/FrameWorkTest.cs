using Moq;
using NUnit.Framework;
using DataLayer.Interfaces;
using Common.Interfaces;
using Common.Models;
using BusinessLayer.Interfaces;
using BusinessLayer;

namespace Test.BusinessLayer
{
    [TestFixture]
    public class FrameWorkTest
    {
        private Mock<IError> error;
        private Mock<IDataService> dataService;
        private Mock<ILogService> logService;
        private Mock<IErrorService> errorService;
        private Mock<IUserService> userService;

        [SetUp]
        public void SetUp()
        {
            error = new Mock<IError>();
            error.Setup(e => e.Message).Returns("Ok");
            error.Setup(e => e.IsError).Returns(false);
            dataService = new Mock<IDataService>();
            dataService.Setup(x => x.InsertItemActive(It.IsAny<IItemActive>())).Returns(error.Object);
            logService = new Mock<ILogService>();
            errorService = new Mock<IErrorService>();
            userService = new Mock<IUserService>();
        }

        [Test]
        public void Add_Item_When_ReturnItemName_ThenEqualToName()
        {
            //Arrange
            IItemActive item = new ItemActive();
            item.DeviceName = "router";
            IFrameWork testObject = new FrameWork(dataService.Object, logService.Object, errorService.Object, userService.Object);

            //Act
            bool ok = testObject.AddItemActive(item);
            var result = testObject.GetItemActive(item.Id);

            //Assert
            Assert.That(result.DeviceName, Is.EqualTo(item.DeviceName));
        }

        [Test]
        public void Change_ItemName()
        {
            //Arrange
            IItemActive item = new ItemActive();
            item.DeviceName = "router";
            IFrameWork testObject = new FrameWork(dataService.Object, logService.Object, errorService.Object, userService.Object);

            //Act
            bool ok = testObject.AddItemActive(item);
            IItemActive change = testObject.GetItemActive(item.Id);
            change.DeviceName = "switch";
            IItemActive result = testObject.GetItemActive(item.Id);

            //Assert
            Assert.That(result.DeviceName, Is.EqualTo("switch"));
        }
    }
}
