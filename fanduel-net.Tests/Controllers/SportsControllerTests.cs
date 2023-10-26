using fanduel_net.Controllers;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Controllers
{
    [TestClass]
    public class SportsControllerTests
    {
        private readonly SportsController _controller;
        private readonly Mock<ISportsService> _service;

        public SportsControllerTests()
        {
            _service = new Mock<ISportsService>();
            _controller = new SportsController(_service.Object);
        }

        [TestMethod]
        public async Task GetSports_ReturnsListOfSports()
        {
            var expectedSports = new List<Sport>
            {
                new Sport("1", "Soccer"),
                new Sport("2", "NFL")
            };

            _service.Setup(s => s.GetSports()).ReturnsAsync(expectedSports);

            var result = await _controller.GetSports();

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task GetSport_ReturnsSportById()
        {
            string sportId = "1"; 
            var expectedSport = new Sport(sportId, "Soccer");

            _service.Setup(s => s.GetSport(sportId)).ReturnsAsync(expectedSport);

            var result = await _controller.GetSport(sportId);

            Assert.IsNotNull(result, "The result should not be null.");
        }
    }
}
