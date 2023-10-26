using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fanduel_net.Tests.Service
{
    [TestClass]
    public class PlayersServiceTests
    {
        private readonly PlayersService _service;
        private readonly Mock<IPlayersRepository> _repository;

        public PlayersServiceTests()
        {
            _repository = new Mock<IPlayersRepository>();
            _service = new PlayersService(_repository.Object);
        }

        [TestMethod]
        public async Task GetPlayers_ReturnsListOfPlayers()
        {
            var expectedPlayers = new List<Player>
            {
                new Player("1", 10, "Lionel Messi", new Team("1", "Test Team", new Sport("1", "Test Sport"))),
                new Player("2", 2, "DeAndre Yedlin", new Team("2", "Test Team", new Sport("1", "Test Sport")))
            };

            _repository.Setup(r => r.GetPlayers()).ReturnsAsync(expectedPlayers);

            var result = await _service.GetPlayers();

            Assert.IsNotNull(result, "The result should not be null.");
            Assert.IsTrue(result.Count > 0, "The count of returned players should be greater than 0.");
        }

        [TestMethod]
        public async Task GetTeamPlayers_ReturnsPlayersForTeam()
        {
            string teamId = "1";
            var expectedPlayers = new List<Player>
            {
                new Player("1", 10, "Lionel Messi", new Team("1", "Test Team", new Sport("1", "Test Sport"))),
                new Player("2", 2, "DeAndre Yedlin", new Team("1", "Test Team", new Sport("1", "Test Sport")))
            };

            _repository.Setup(r => r.GetTeamPlayers(teamId)).ReturnsAsync(expectedPlayers);

            var result = await _service.GetTeamPlayers(teamId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddPlayer_AddsPlayerToRepository()
        {
            var newPlayer = new Player("9", 99, "Test Player", new Team("3", "Test Team", new Sport("2", "Test Sport")));

            _repository.Setup(r => r.AddPlayer(newPlayer)).Returns(newPlayer);

            var addedPlayer = _service.AddPlayer(newPlayer);

            Assert.IsNotNull(addedPlayer, "The added player should not be null.");
        }
    }
}
