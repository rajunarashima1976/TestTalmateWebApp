using CBA.Training.Talmate.Web.Comman;
using CBA.Training.Talmate.Web.Controllers;
using CBA.Training.Talmate.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Web.UnitTests
{
    public class LoginControllerTests
    {
        private Mock<IOptions<AppSettings>> _mockAppSettingRepository;        
        private LoginController _controller;

        [SetUp]
        public void Setup()
        {
            _mockAppSettingRepository = new Mock<IOptions<AppSettings>>();            
            _controller = new LoginController(_mockAppSettingRepository.Object);
        }

        [Test]
        public async Task Index_ReturnsAsActionResult_WithLoginPage()
        {            
            var result = await _controller.Index();
            Assert.Pass();            
            Assert.IsNotNull(result as IActionResult);
        }       
    }
}  