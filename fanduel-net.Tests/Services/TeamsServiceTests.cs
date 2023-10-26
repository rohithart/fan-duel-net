using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Service
{
    [TestClass]
    public class TeamsServiceTests
    {
        private readonly TeamsService _service;
        private readonly Mock<ITeamsRepository> _repository;

        public TeamsServiceTests()
        {
            _repository = new Mock<ITeamsRepository>();
            _service = new TeamsService(_repository.Object);
        }

        [TestMethod]
        public async Task GetTeams_ReturnsListOfTeams()
        {
            var expectedTeams = new List<Team>
            {
                new Team("1", "Manchester United", new Sport("1", "Soccer")),
                new Team("2", "Inter Miami", new Sport("1", "Soccer"))
            };

            _repository.Setup(r => r.GetTeams()).ReturnsAsync(expectedTeams);

            var result = await _service.GetTeams();

            Assert.IsNotNull(result, "The result should not be null.");
            Assert.IsTrue(result.Count == 2, "The count of returned teams should be 2.");
        }

        [TestMethod]
        public async Task GetSportsTeams_ReturnsTeamsForSport()
        {
            string sportId = "1";
            var expectedTeams = new List<Team>
            {
                new Team("1", "Manchester United", new Sport("1", "Soccer")),
                new Team("2", "Inter Miami", new Sport("1", "Soccer")),
            };

            _repository.Setup(r => r.GetSportsTeams(sportId)).ReturnsAsync(expectedTeams);

            var result = await _service.GetSportsTeams(sportId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2, "The count of returned teams should be 2.");
        }

        [TestMethod]
        public async Task GetTeam_ReturnsTeamById()
        {
            string teamId = "1";
            var expectedTeam = new Team(teamId, "Manchester United", new Sport("1", "Soccer"));

            _repository.Setup(r => r.GetTeam(teamId)).ReturnsAsync(expectedTeam);

            var result = await _service.GetTeam(teamId);

            Assert.AreEqual(expectedTeam, result);
        }
    }
}
