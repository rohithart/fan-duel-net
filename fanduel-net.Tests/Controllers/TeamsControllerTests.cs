using fanduel_net.Controllers;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Controllers
{
    [TestClass]
    public class TeamsControllerTests
    {
        private readonly TeamsController _controller;
        private readonly Mock<ITeamsService> _service;

        public TeamsControllerTests()
        {
            _service = new Mock<ITeamsService>();
            _controller = new TeamsController(_service.Object);
        }

        [TestMethod]
        public async Task GetTeams_ReturnsNotNullResult()
        {
            var expectedTeams = new List<Team>
            {
                new Team("1", "Manchester United", new Sport("1", "Soccer")),
                new Team("2", "Inter Miami", new Sport("1", "Soccer"))
            };

            _service.Setup(s => s.GetTeams()).ReturnsAsync(expectedTeams);

            var result = await _controller.GetTeams();

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task GetSportsTeam_ReturnsNotNullResult()
        {
            var expectedTeams = new List<Team>
            {
                new Team("1", "Manchester United", new Sport("1", "Soccer")),
                new Team("2", "Inter Miami", new Sport("1", "Soccer"))
            };

            _service.Setup(s => s.GetSportsTeams("1")).ReturnsAsync(expectedTeams);

            var result = await _controller.GetSportsTeam("1");

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task GetTeam_ReturnsNotNullResult()
        {
            var expectedTeam = new Team("1", "Manchester United", new Sport("1", "Soccer"));

            _service.Setup(s => s.GetTeam("1")).ReturnsAsync(expectedTeam);

            var result = await _controller.GetTeam("1");

            Assert.IsNotNull(result, "The result should not be null.");
        }
    }
}
