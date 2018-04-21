using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using EmployeePayrollDeductions.Domain.Services;
using EmployeePayrollDeductions.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using EmployeePayrollDeductions.Web;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Tests
{
    [TestClass]
    public class EmployeeDeductionsTests
    {
        private Mock<IRepository<Employee>> _employeeRepositoryMock;
        private EmployeeService _employeeService;
        private Employee _employee;
        
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        [TestInitialize]
        public void Initialize()
        {
            _employeeRepositoryMock = new Mock<IRepository<Employee>>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object);            
        }


        [TestMethod]
        public void CalculateBenefitCosts_EmployeeOnlyNoDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike",
                LastName = "Schwartz"
            };

            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            //Act
            var response = _employeeService.Get(1);

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(1000M, employeeMapped.TotalBenefitCost);
        }

        [TestMethod]
        public void CalculateBenefitCosts_EmployeeOnlyWithDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Andy",
                LastName = "Schwartz"
            };

            //Act
            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(900M, employeeMapped.TotalBenefitCost);
        }

        [TestMethod]
        public void CalculateBenefitCosts_EmployeeWithOneDependentNoDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike",
                LastName = "Schwartz"
            };

            var dependent1 = new Dependent()
            {
                FirstName = "Elle",
                LastName = "Schwartz"
            };

            _employee.Dependents.Add(dependent1);

            //Act
            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(1500M, employeeMapped.TotalBenefitCost);
        }

        [TestMethod]
        public void CalculateBenefitCosts_EmployeeWithTwoDependentsNoDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike",
                LastName = "Schwartz"
            };

            var dependent1 = new Dependent()
            {
                FirstName = "Elle",
                LastName = "Schwartz"
            };

            var dependent2 = new Dependent()
            {
                FirstName = "Lori",
                LastName = "Schwartz"
            };

            _employee.Dependents.Add(dependent1);
            _employee.Dependents.Add(dependent2);

            //Act
            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(2000M, employeeMapped.TotalBenefitCost);
        }

        [TestMethod]
        public void CalculateBenefitCosts_EmployeeWithOneDependentThatHasDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike",
                LastName = "Schwartz"
            };

            var dependent1 = new Dependent()
            {
                FirstName = "Allie",
                LastName = "Schwartz"
            };

            _employee.Dependents.Add(dependent1);

            //Act
            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(1450M, employeeMapped.TotalBenefitCost);
        }

        [TestMethod]
        public void CalculateBenefitCosts_EmployeeWithTwoDependentsWithDiscount_ReturnsValidCost()
        {
            //Arrange
            _employee = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike",
                LastName = "Schwartz"
            };

            var dependent1 = new Dependent()
            {
                FirstName = "Allie",
                LastName = "Schwartz"
            };

            var dependent2 = new Dependent()
            {
                FirstName = "Adam",
                LastName = "Schwartz"
            };

            _employee.Dependents.Add(dependent1);
            _employee.Dependents.Add(dependent2);

            //Act
            _employeeRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(_employee));

            var employeeMapped = Mapper.Map<Employee, EmployeeViewModel>(_employee);

            //Assert
            Assert.AreEqual(1900M, employeeMapped.TotalBenefitCost);
        }
    }
}
