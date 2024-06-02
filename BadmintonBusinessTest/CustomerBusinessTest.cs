using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using BadmintonRentingData;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using Moq;
using System;

namespace BadmintonBusinessTest
{
    public class CustomerBusinessTest
    {
        [Fact]
        public async Task Create_ShouldReturnSuccessResult_WhenCustomerIsCreated()
        {
            // Arrange
            var newCustomerDTO = new CustomerRequestDTO
            {
                CustomerName = "John Doe",
                Phone = 123456789,
                Email = "john@example.com",
                IsStatus = "Active"
            };

            var mockCustomerRepository = new Mock<CustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.CreateAsync(It.IsAny<Customer>())).ReturnsAsync(1);

            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var customerBusiness = new CustomerBusiness(mockUnitOfWork.Object);

            // Act
            var result = await customerBusiness.Create(newCustomerDTO);

            // Assert
            Assert.Equal(Const.SUCCESS_CREATE_CODE, result.Status);
            Assert.Equal(Const.SUCCESS_CREATE_MSG, result.Message);
        }

        [Fact]
        public async Task DeleteById_ShouldReturnSuccessResult_WhenCustomerIsDeleted()
        {
            // Arrange
            var customerId = 1;

            var mockCustomer = new Mock<Customer>();
            var mockCustomerRepository = new Mock<CustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(mockCustomer.Object);
            mockCustomerRepository.Setup(repo => repo.RemoveAsync(mockCustomer.Object)).ReturnsAsync(true);

            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var customerBusiness = new CustomerBusiness(mockUnitOfWork.Object);

            // Act
            var result = await customerBusiness.DeleteById(customerId);

            // Assert
            Assert.Equal(Const.SUCCESS_DELETE_CODE, result.Status);
            Assert.Equal(Const.SUCCESS_DELETE_MSG, result.Message);
        }

        [Fact]
        public async Task GetAll_ShouldReturnSuccessResult_WhenCustomersExist()
        {
            // Arrange
            var customers = new List<Customer> { new Customer { CustomerId = 1, CustomerName = "John Doe" } };

            var mockCustomerRepository = new Mock<CustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(customers);

            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var customerBusiness = new CustomerBusiness(mockUnitOfWork.Object);

            // Act
            var result = await customerBusiness.GetAll();

            // Assert
            Assert.Equal(Const.SUCCESS_READ_CODE, result.Status);
            Assert.Equal(Const.SUCCESS_READ_MSG, result.Message);
            Assert.Equal(customers, result.Data);
        }

        [Fact]
        public async Task GetById_ShouldReturnSuccessResult_WhenCustomerExists()
        {
            // Arrange
            var customerId = 1;
            var mockCustomer = new Mock<Customer>();
            var mockCustomerRepository = new Mock<CustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(mockCustomer.Object);

            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var customerBusiness = new CustomerBusiness(mockUnitOfWork.Object);

            // Act
            var result = await customerBusiness.GetById(customerId);

            // Assert
            Assert.Equal(Const.SUCCESS_READ_CODE, result.Status);
            Assert.Equal(Const.SUCCESS_READ_MSG, result.Message);
            Assert.Equal(mockCustomer.Object, result.Data);
        }

        [Fact]
        public async Task Update_ShouldReturnSuccessResult_WhenCustomerIsUpdated()
        {
            // Arrange
            var customerId = 1;
            var newCustomerDTO = new CustomerRequestDTO
            {
                CustomerName = "Jane Doe",
                Phone = 987654321,
                Email = "jane@example.com",
                IsStatus = "Inactive"
            };

            var mockCustomerRepository = new Mock<CustomerRepository>();
            // Mock GetByIdAsync instead of GetById
            mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync((Customer)null);
            mockCustomerRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Customer>())).ReturnsAsync(1);

            var mockUnitOfWork = new Mock<UnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var customerBusiness = new CustomerBusiness(mockUnitOfWork.Object);

            // Act
            var result = await customerBusiness.Update(customerId, newCustomerDTO);

            // Assert
            Assert.Equal(Const.SUCCESS_UPDATE_CODE, result.Status);
            Assert.Equal(Const.SUCCESS_UPDATE_MSG, result.Message);
        }
    }
}