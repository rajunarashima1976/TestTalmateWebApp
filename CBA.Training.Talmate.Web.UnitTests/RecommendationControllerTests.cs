using AutoMapper;
using CBA.Training.Talmate.Web.Comman;
using CBA.Training.Talmate.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Web.UnitTests
{
    public class RecommendationControllerTests
    {
        private Mock<IOptions<AppSettings>> _mockAppSettingRepository;
        private Mock<IMapper> _mockMapperRepository;
        private RecommendationController _controller;

        [SetUp]
        public void Setup()
        {
            _mockAppSettingRepository = new Mock<IOptions<AppSettings>>();
            _mockMapperRepository = new Mock<IMapper>();
            _controller = new RecommendationController(_mockMapperRepository.Object, _mockAppSettingRepository.Object);
        }        
    }
}
