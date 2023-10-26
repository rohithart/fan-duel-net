using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fanduel_net.Tests.Repositories
{
    [TestClass]
    public class PlayersRepositoryTests
    {
        private readonly IPlayersRepository _repository;

        public PlayersRepositoryTests()
        {
            _repository = new PlayersRepository();
        }

        [TestMethod]
        public async Task GetPlayers_ReturnsAllPlayers()
        {
            var result = await _repository.GetPlayers();

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerData.AllPlayers.Count, result.Count);
        }

        [TestMethod]
        public async Task GetTeamPlayers_ReturnsPlayersForTeam()
        {
            string teamId = "1";

            var result = await _repository.GetTeamPlayers(teamId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddPlayer_AddsPlayerToData()
        {
            var newPlayer = new Player("9", 99, "Test Player", new Team("6", "Test Team", new Sport("3", "Test Sport")));

            var addedPlayer = _repository.AddPlayer(newPlayer);

            Assert.IsNotNull(addedPlayer);
        }
    }
}
