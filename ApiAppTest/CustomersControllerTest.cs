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

        #region Get Customer Cases
        [Fact]
        public async Task GetCustomers_ShouldReturnActionResultOfCustomersWith200StatusCode()
        {
            //Arrange
            var customers = _fixture.CreateMany<CustomerDto>(3).ToList();
            A.CallTo(() => _customerServices.GetCustomers()).Returns(customers);

            //Act
            var result = await _sut.GetCustomers() as OkObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomers()).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            var returnValue = Assert.IsType<List<CustomerDto>>(result.Value);
            Assert.Equal(customers.Count, returnValue.Count());
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public async Task GetCustomers_ShouldReturn404NotFoundResult()
        {
            //Arrange
            var products = new List<CustomerDto>();
            A.CallTo(() => _customerServices.GetCustomers()).Returns(products);

            //Act 
            var resultNotFound = new NotFoundResult();
            var result = await _sut.GetCustomers() as NotFoundObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomers()).MustHaveHappenedOnceExactly();

            if (result.StatusCode == 404)
            {
                resultNotFound = new NotFoundResult();
            }

            Assert.Equal(StatusCodes.Status404NotFound, resultNotFound.StatusCode);
        }
        #endregion


        #region Customer by Category filter
        [Fact]
        public async Task GetCustomersByCategory_ShouldReturnActionResultOfCustomersWith200StatusCode()
        {
            //Arrange
            string _categoryType = "Corporate";
            var customers = _fixture.CreateMany<CustomerDto>(3).ToList();
            A.CallTo(() => _customerServices.GetCustomersByCategory(_categoryType)).Returns(customers);

            //Act
            var result = await _sut.GetCustomersByCategory(_categoryType) as OkObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomersByCategory(_categoryType)).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            var returnValue = Assert.IsType<List<CustomerDto>>(result.Value);
            Assert.Equal(customers.Count, returnValue.Count());
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public async Task GetCustomersByCategory_ShouldReturn404NotFoundResult()
        { 
            string _categoryType = "CorporateNotFound";
            //Arrange
            var products = new List<CustomerDto>();
            A.CallTo(() => _customerServices.GetCustomersByCategory(_categoryType)).Returns(products);

            //Act 
            var resultNotFound = new NotFoundResult();
            var result = await _sut.GetCustomersByCategory(_categoryType) as NotFoundObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomersByCategory(_categoryType)).MustHaveHappenedOnceExactly();

            if (result.StatusCode == 404)
            {
                resultNotFound = new NotFoundResult();
            }

            Assert.Equal(StatusCodes.Status404NotFound, resultNotFound.StatusCode);
        }

        #endregion


        #region Customer Categories distinct values
        [Fact]
        public async Task GetCustomerCategories_ShouldReturnActionResultOfCustomersWith200StatusCode()
        {
            //Arrange 
            var categories = _fixture.CreateMany<string>(2).ToList();
            A.CallTo(() => _customerServices.GetCustomerCategories()).Returns(categories);

            //Act
            var result = await _sut.CustomerCategories() as OkObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomerCategories()).MustHaveHappenedOnceExactly();
            Assert.NotNull(result);
            var returnValue = Assert.IsType<List<string>>(result.Value);
            Assert.Equal(categories.Count, returnValue.Count());
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public async Task GetCustomerCategories_ShouldReturn404NotFoundResult()
        { 
            //Arrange
            var products = new List<string>();
            A.CallTo(() => _customerServices.GetCustomerCategories()).Returns(products);

            //Act 
            var resultNotFound = new NotFoundResult();
            var result = await _sut.CustomerCategories() as NotFoundObjectResult;

            //Assert
            A.CallTo(() => _customerServices.GetCustomerCategories()).MustHaveHappenedOnceExactly();

            if (result.StatusCode == 404)
            {
                resultNotFound = new NotFoundResult();
            }

            Assert.Equal(StatusCodes.Status404NotFound, resultNotFound.StatusCode);
        }
        #endregion
    }
}
