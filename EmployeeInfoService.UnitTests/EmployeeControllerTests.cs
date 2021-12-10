using EmployeeInfos.Controllers;
using EmployeeInfos.Models;
using EmployeeInfos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmployeeInfoService.UnitTests
{
    /// <summary>
    /// Test Class for Employee Controller
    /// </summary>
    [TestFixture]
    public class EmployeeControllerTests
    {
        private  Mock<IEmployeeServices> mockEmpServices;
        public EmployeeController employeeController;

        /// <summary>
        /// Setup method
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            mockEmpServices = new Mock<IEmployeeServices>();
            employeeController = new EmployeeController(mockEmpServices.Object);
        }

        /// <summary>
        /// Unit Test for Index and returns Employee list
        /// </summary>
        [Test]
        public void Index_Success_ReturnsEmployee()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetAllEmployess()).Returns(TestHelperClass.GetAllEmployees());

            //Act
            var result = employeeController.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(typeof(List<Employee>), result.Model.GetType());
            mockEmpServices.Verify(x => x.GetAllEmployess(), Times.Once);
        }

        /// <summary>
        /// Unit Test for Index and returns not found
        /// </summary>
        [Test]
        public void Index_Success_ReturnsNotFound()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetAllEmployess()).Returns(new List<Employee>());

            //Act
            var result = employeeController.Index() as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.GetAllEmployess(), Times.Once);
        }

        /// <summary>
        /// Unit Test for Create and Returns Create View
        /// </summary>
        [Test]
        public void Create_Success_ReturnsView()
        {
            //Arrange
            mockEmpServices.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns(true);

            //Act
            var result = employeeController.Create(It.IsAny<Employee>()) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.AddEmployee(It.IsAny<Employee>()), Times.Once);
        }

        /// <summary>
        /// Test for Create and Returns NotFound
        /// </summary>
        [Test]
        public void Create_Success_ReturnsNotFound()
        {
            //Arrange
            mockEmpServices.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Returns(false);

            //Act
            var result = employeeController.Create(It.IsAny<Employee>()) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.AddEmployee(It.IsAny<Employee>()), Times.Once);
        }

        /// <summary>
        /// Test for Edit and Returns Employee
        /// </summary>
        [Test]
        public void Edit_Success_ReturnsEmployee()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(TestHelperClass.GetEmployee());

            //Act
            var result = employeeController.Edit(3) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.GetEmployeeById(It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Test for Edit and Return Employee
        /// </summary>
        [Test]
        public void EditWithParamater_Success_ReturnsEmployee()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(TestHelperClass.GetEmployee());
            mockEmpServices.Setup(x => x.UpdateEmployee(It.IsAny<Employee>())).Returns(true);

            //Act
            var result = employeeController.Edit(2, TestHelperClass.GetEmployee()) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.UpdateEmployee(It.IsAny<Employee>()), Times.Once);
            mockEmpServices.Verify(x => x.GetEmployeeById(It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Test for Edit and Returns NotFound
        /// </summary>
        [Test]
        public void Edit_Success_ReturnsNotFound()
        {
            //Act
            var result = employeeController.Edit(null) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.GetEmployeeById(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Test for Delete and Returns Employee
        /// </summary>
        [Test]
        public void Delete_Success_ReturnsEmployee()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(TestHelperClass.GetEmployee());

            //Act
            var result = employeeController.Delete(3) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.GetEmployeeById(It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Test for Delete and Returns Employee
        /// </summary>
        [Test]
        public void DeleteWithParameter_Success_ReturnsEmployee()
        {
            //Arrange
            mockEmpServices.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(TestHelperClass.GetEmployee());
            mockEmpServices.Setup(x => x.DeleteEmployee(It.IsAny<Employee>())).Returns(true);

            //Act
            var result = employeeController.Delete(3, It.IsAny<IFormCollection>()) as ViewResult;

            //Assert
            mockEmpServices.Verify(x => x.GetEmployeeById(It.IsAny<int>()), Times.Once);
            mockEmpServices.Verify(x => x.DeleteEmployee(It.IsAny<Employee>()), Times.Once);
        }
    }
}
