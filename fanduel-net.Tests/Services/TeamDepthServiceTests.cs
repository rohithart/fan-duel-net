using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Service;

namespace fanduel_net.Tests.Service
{
    [TestClass]
    public class TeamDepthServiceTests
    {
        private TeamDepthService teamDepthService;
        private Mock<IPlayersService> playersServiceMock;
        private Mock<ITeamDepthRepository> repositoryMock;

        public TeamDepthServiceTests()
        {
            playersServiceMock = new Mock<IPlayersService>();
            repositoryMock = new Mock<ITeamDepthRepository>();
            teamDepthService = new TeamDepthService(repositoryMock.Object, playersServiceMock.Object);
        }

        [TestMethod]
        public async Task GetTeamDepth_ReturnsTeamDepthForValidId()
        {
            string teamId = "1";
            var expectedTeamDepth = new TeamDepth("1", new Team("1", "Manchester United", new Sport("1", "Soccer")));
            repositoryMock.Setup(r => r.GetTeamDepth(It.IsAny<string>())).ReturnsAsync(expectedTeamDepth);

            var result = await teamDepthService.GetTeamDepth(teamId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTeamDepth, result);
        }

        [TestMethod]
        public async Task AddPlayer_ThrowsArgumentNullExceptionForNullPosition()
        {
            string teamId = "1";
            string playerId = "playerId";
            int? positionDepth = 1;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.AddPlayer(teamId, null, playerId, positionDepth));
        }

        [TestMethod]
        public async Task AddPlayer_ThrowsArgumentNullExceptionForNullPlayerId()
        {
            string teamId = "1";
            string position = "QB";
            int? positionDepth = 1;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.AddPlayer(teamId, position, null, positionDepth));
        }

        [TestMethod]
        public async Task AddPlayer_ThrowsArgumentNullExceptionForNullPlayer()
        {
            string teamId = "1";
            string position = "QB";
            int? positionDepth = 1;

            playersServiceMock.Setup(r => r.GetPlayer("")).Returns((Player?)null);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.AddPlayer(teamId, position, null, positionDepth));
        }

        [TestMethod]
        public async Task RemovePlayer_ThrowsArgumentNullExceptionForNullPosition()
        {
            string teamId = "1";
            string playerId = "playerId";

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.RemovePlayer(teamId, null, playerId));
        }

        [TestMethod]
        public async Task RemovePlayer_ThrowsArgumentNullExceptionForNullPlayerId()
        {
            string teamId = "1";
            string position = "QB";

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.RemovePlayer(teamId, position, null));
        }

        [TestMethod]
        public async Task RemovePlayer_ThrowsArgumentNullExceptionForNullPlayer()
        {
            string teamId = "1";
            string position = "QB";

            playersServiceMock.Setup(r => r.GetPlayer("")).Returns((Player?)null);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.RemovePlayer(teamId, position, null));
        }

        [TestMethod]
        public async Task GetBackupPlayers_ThrowsArgumentNullExceptionForNullPosition()
        {
            string teamId = "1";
            string playerId = "playerId";
            int depth = 1;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.GetBackupPlayers(teamId, null, playerId, depth));
        }

        [TestMethod]
        public async Task GetBackupPlayers_ThrowsArgumentNullExceptionForNullPlayerId()
        {
            string teamId = "1";
            string position = "QB";
            int depth = 1;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.GetBackupPlayers(teamId, position, null, depth));
        }

        [TestMethod]
        public async Task GetBackupPlayers_ThrowsArgumentNullExceptionForNullPlayer()
        {
            string teamId = "1";
            string position = "QB";
            int depth = 1;

            playersServiceMock.Setup(r => r.GetPlayer("")).Returns((Player?)null);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => teamDepthService.GetBackupPlayers(teamId, position, null, depth));
        }
    }
}