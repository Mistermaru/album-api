using Album.Api.Models;
using System;
using System.Net;
using Xunit;

namespace Album.Api.Tests
{
    public class GreetingServiceTest
    {

        [Fact]
        public void When_Name_Given_Correctly()
        {
            //arrange
            var name = "John Wick";
            GreetingService greetingService = new GreetingService();
            Response expectedRes = new Response();
            expectedRes.ResponseContent = $"Hello {name}";

            //act
            Response actualRes = greetingService.Greet(name);

            //Assert
            Assert.Equal(expectedRes.ResponseContent, actualRes.ResponseContent);
        }

        [Fact]
        public void When_WhiteSpace_Given_For_Name()
        {
            //arrange
            var name = " ";
            GreetingService greetingService = new GreetingService();
            Response expectedRes = new Response();
            expectedRes.ResponseContent = "Hello World";

            //act
            Response actualRes = greetingService.Greet(name);

            //Assert
            Assert.Equal(expectedRes.ResponseContent, actualRes.ResponseContent);
        }

        [Fact]
        public void When_Null_Given_For_Name()
        {
            //arrange
            GreetingService greetingService = new GreetingService();
            Response expectedRes = new Response();
            expectedRes.ResponseContent = "Hello World";

            //act
            Response actualRes = greetingService.Greet(null);

            //Assert
            Assert.Equal(expectedRes.ResponseContent, actualRes.ResponseContent);
        }
    }
}
