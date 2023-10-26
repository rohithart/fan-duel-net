using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fanduel_net.Tests.Repositories
{
    [TestClass]
    public class TeamsRepositoryTests
    {
        private readonly ITeamsRepository _repository;

        public TeamsRepositoryTests()
        {
            _repository = new TeamsRepository();
        }

        [TestMethod]
        public async Task GetTeams_ReturnsAllTeams()
        {
            var result = await _repository.GetTeams();

            Assert.IsNotNull(result);
            Assert.AreEqual(TeamsData.AllTeams.Count, result.Count);
        }

        [TestMethod]
        public async Task GetTeam_ReturnsTeamById()
        {
            string teamId = TeamsData.ManU.Id;

            var result = await _repository.GetTeam(teamId);

            Assert.IsNotNull(result);
            Assert.AreEqual(teamId, result.Id);
        }

        [TestMethod]
        public async Task GetTeam_ReturnsNullForInvalidId()
        {
            string invalidTeamId = "999";

            var result = await _repository.GetTeam(invalidTeamId);

            Assert.IsNull(result);
        }
    }
}
