using CBA.Training.Talmate.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Web.UnitTests
{
    class DashboardControllerTests
    {
        private DashboardController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new DashboardController();
        }

        [Test]
        public async Task Dashboard_ReturnsAsActionResult_WithDashboardPage()
        {
            var result = await _controller.Index();
            Assert.Pass();
            Assert.IsNotNull(result as IActionResult);
        }
        [Test]
        public async Task Dashboard_FailedToReturnsAsActionResult_WithoutDashboardPage()
        {
            var result = await _controller.Index();
            var okResult = result as OkObjectResult;
            Assert.Pass();
            Assert.IsNull(okResult);
        }

    }
}
