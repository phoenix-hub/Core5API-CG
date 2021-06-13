using System;
using ApiApp.Controllers;
using ApiApp.Services;
using ApiApp.Models;
using System.Collections.Generic;
using Xunit;
using FakeItEasy;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ApiAppTest
{
    public class CustomersControllerTest
    {
        //Fakes
        private readonly ICustomerServices _customerServices;

        //Dummy Data Generator
        private readonly Fixture _fixture;

        //System under test
        private readonly CustomersController _sut;

        public CustomersControllerTest()
        {
            _customerServices = A.Fake<ICustomerServices>();
            _sut = new CustomersController(_customerServices);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetCustomer_ShouldReturnActionResultOfCustomersWith200StatusCode()
        {
            //Arrange
            var customers = _fixture.CreateMany<CustomerDto>(3).ToList();
            A.CallTo(() => _customerServices.GetCustomer()).Returns(customers);

            //Act
            var result = await _sut.GetCustomers() as OkObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomer()).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            var returnValue = Assert.IsType<List<CustomerDto>>(result.Value);
            Assert.Equal(customers.Count, returnValue.Count());
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public async Task GetCustomer_Found_ShouldReturn404NotFoundResult()
        { 
            //Arrange
            var customers = new List<CustomerDto>();
            A.CallTo(() => _customerServices.GetCustomer()).Returns(customers);

            //Act
            var result = await _sut.GetCustomers() as NotFoundResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomer()).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
