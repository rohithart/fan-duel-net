using fanduel_net.Controllers;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Controllers
{
    [TestClass]
    public class PlayersControllerTests
    {
        private readonly PlayersController _controller;
        private readonly Mock<IPlayersService> _service;

        public PlayersControllerTests()
        {
            _service = new Mock<IPlayersService>();
            _controller = new PlayersController(_service.Object);
        }

        [TestMethod]
        public async Task GetPlayers_ReturnsNotNullResult()
        {
            var expectedPlayers = new List<Player>
            {
                new Player("1", 10, "Lionel Messi", new Team("1", "Manchester United", new Sport("1", "Soccer"))),
                new Player("2", 2, "DeAndre Yedlin", new Team("1", "Manchester United", new Sport("1", "Soccer")))
            };

            _service.Setup(s => s.GetPlayers()).ReturnsAsync(expectedPlayers);

            var result = await _controller.GetPlayers();

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task GetTeamPlayers_ReturnsNotNullResult()
        {
            var expectedPlayers = new List<Player>
            {
                new Player("1", 10, "Lionel Messi", new Team("1", "Manchester United", new Sport("1", "Soccer"))),
                new Player("2", 2, "DeAndre Yedlin", new Team("1", "Manchester United", new Sport("1", "Soccer")))
            };

            _service.Setup(s => s.GetTeamPlayers("1")).ReturnsAsync(expectedPlayers);

            var result = await _controller.GetTeamPlayers("1");

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public void AddPlayer_ReturnsNotNullResult()
        {
            var newPlayer = new Player("3", 7, "New Player", new Team("1", "Manchester United", new Sport("1", "Soccer")));
            _service.Setup(s => s.AddPlayer(It.IsAny<Player>())).Returns(newPlayer);

            var result = _controller.AddPlayer(newPlayer);

            Assert.IsNotNull(result, "The result should not be null.");
        }
    }
}
