using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fanduel_net.Tests.Repositories
{
    [TestClass]
    public class SportsRepositoryTests
    {
        private readonly ISportsRepository _repository;

        public SportsRepositoryTests()
        {
            _repository = new SportsRepository();
        }

        [TestMethod]
        public async Task GetSports_ReturnsAllSports()
        {
            var result = await _repository.GetSports();

            Assert.IsNotNull(result);
            Assert.AreEqual(SportsData.AllSports.Count, result.Count);
        }

        [TestMethod]
        public async Task GetSport_ReturnsSportById()
        {
            string sportId = SportsData.Soccer.Id;

            var result = await _repository.GetSport(sportId);

            Assert.IsNotNull(result);
            Assert.AreEqual(sportId, result.Id);
        }

        [TestMethod]
        public async Task GetSport_ReturnsNullForInvalidId()
        {
            string invalidSportId = "999";

            var result = await _repository.GetSport(invalidSportId);

            Assert.IsNull(result);
        }
    }
}
