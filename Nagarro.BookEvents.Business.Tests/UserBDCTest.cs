using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.BookEvents.Shared;
using System;

namespace Nagarro.BookEvents.Business.Tests
{
    [TestClass]
    public class UserBDCTest
    {
        private readonly IUserBDC userBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<IUserDAC> mockUserDac;


        public UserBDCTest()
        { 
            mockDacFactory = new Mock<IDACFactory>();
            mockUserDac = new Mock<IUserDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockUserDac.Object);
            userBDC = new UserBDC(mockDacFactory.Object);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            mockUserDac.Setup(x => x.CreateUser(It.IsAny<UserDTO>())).Returns(userDTO);
            var response = userBDC.CreateUser(userDTO);
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }

        [TestMethod]
        public void LoginUserTest()
        {
            mockUserDac.Setup(x => x.LoginUser(It.IsAny<UserDTO>())).Returns(userDTO);
            var response = userBDC.LoginUser(userDTO);
            System.Diagnostics.Debug.WriteLine(response.Message);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);
        }

        private UserDTO userDTO = new UserDTO
        {
            FullName = "Heeman",
            Email = "hy@g.com",
        };

        private UserDTO userDTO2 = new UserDTO
        {
            Email = "ajith@gmail.com",
            Password = "Vkgsdasdasthira@1997"
        };
    }
}
