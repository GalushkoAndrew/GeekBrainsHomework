using Xunit;
using Moq;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces;
using GeekBrains.Learn.TimeSheets.Controllers;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TimeSheets.UnitTest
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void EmployeeManagerCreateCalled_EmployeeController_Test()
        {
            var mockEmployeeManager = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(mockEmployeeManager.Object);
            mockEmployeeManager.Setup(x => x.Create(It.IsAny<EmployeeDto>()));
            try {
                controller.Create(It.IsAny<EmployeeDto>());
            }
            catch (Exception) {
            }
            mockEmployeeManager.VerifyAll();
        }

        [Fact]
        public void EmployeeManagerCreateOk_EmployeeController_Test()
        {
            var managerResult = new OperationResult(null);
            var result = EmployeeManagerCreate_EmployeeController_Test(managerResult);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void EmployeeManagerCreateBadRequest_EmployeeController_Test()
        {
            var managerResult = new OperationResult(null) {
                IsSuccess = false
            };
            var result = EmployeeManagerCreate_EmployeeController_Test(managerResult);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void EmployeeManagerGetByIdCalled_EmployeeController_Test()
        {
            var mockEmployeeManager = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(mockEmployeeManager.Object);
            mockEmployeeManager.Setup(x => x.GetById(It.IsAny<int>()));
            try {
                controller.GetById(It.IsAny<int>());
            }
            catch (Exception) {
            }
            mockEmployeeManager.VerifyAll();
        }

        [Fact]
        public void EmployeeManagerGetByIdOk_EmployeeController_Test()
        {
            var rand = new Random();
            var managerResult = new EmployeeDto() { Id = rand.Next()};
            var result = EmployeeManagerGetById_EmployeeController_Test(managerResult);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(managerResult.Id, ((result as OkObjectResult).Value as EmployeeDto).Id);
        }

        private IActionResult EmployeeManagerCreate_EmployeeController_Test(OperationResult operationResult)
        {
            var mockEmployeeManager = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(mockEmployeeManager.Object);
            mockEmployeeManager.Setup(x => x.Create(It.IsAny<EmployeeDto>())).Returns(operationResult);
            return controller.Create(It.IsAny<EmployeeDto>());
        }

        private IActionResult EmployeeManagerGetById_EmployeeController_Test(EmployeeDto operationResult)
        {
            var mockEmployeeManager = new Mock<IEmployeeManager>();
            var controller = new EmployeeController(mockEmployeeManager.Object);
            mockEmployeeManager.Setup(x => x.GetById(It.IsAny<int>())).Returns(operationResult);
            return controller.GetById(It.IsAny<int>());
        }
    }
}
