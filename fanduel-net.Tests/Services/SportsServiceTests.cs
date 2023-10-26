using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Service
{
    [TestClass]
    public class SportsServiceTests
    {
        private readonly SportsService _service;
        private readonly Mock<ISportsRepository> _repository;

        public SportsServiceTests()
        {
            _repository = new Mock<ISportsRepository>();
            _service = new SportsService(_repository.Object);
        }

        [TestMethod]
        public async Task GetSports_ReturnsListOfSports()
        {
            var expectedSports = new List<Sport>
            {
                new Sport("1", "Soccer"),
                new Sport("2", "NFL")

            };

            _repository.Setup(r => r.GetSports()).ReturnsAsync(expectedSports);

            var result = await _service.GetSports();

            Assert.IsNotNull(result, "The result should not be null.");
            Assert.IsTrue(result.Count == 2, "The count of returned sports should be 2.");
        }

        [TestMethod]
        public async Task GetSport_ReturnsSportById()
        {
            string sportId = SportsData.Soccer.Id;
            var expectedSport = SportsData.Soccer;

            _repository.Setup(r => r.GetSport(sportId)).ReturnsAsync(expectedSport);

            var result = await _service.GetSport(sportId);

            Assert.AreEqual(expectedSport, result);
        }
    }
}
