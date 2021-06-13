using System;
using ApiApp.Controllers;
using ApiApp.Services;
using ApiApp.Models;
using System.Collections.Generic;
using Xunit;
using FakeItEasy;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppTest
{
    public class CustomersControllerTest
    {
        [Fact]
        public async Task GetCustomers_Sucess_Results()
        {
            //Arrange
            int count = 10;
            var fakeData = A.CollectionOfDummy<CustomerDto>(count).AsEnumerable();
            var dataStore = A.Fake<ICustomerServices>();
            A.CallTo(()=> dataStore.GetCustomer()).Returns(Task.FromResult(fakeData));
            var controller = new CustomersController(dataStore);

            //Act 
            var actionResult = await controller.GetCustomers();

            //Assert   
            var result = actionResult.ExecuteResultAsync.result as OkObjectResult;

            Assert.AreEqual(result, result.Message);
        }

        [Fact]
        public void GetCustomers_NotFound_Results()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void GetCustomers_Failier_Results()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
