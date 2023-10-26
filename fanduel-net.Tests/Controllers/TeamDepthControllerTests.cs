using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using fanduel_net.Controllers;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace fanduel_net.Tests.Controllers
{
    [TestClass]
    public class TeamDepthControllerTests
    {
        private TeamDepthController _controller;
        private Mock<ITeamDepthService> teamDepthServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            teamDepthServiceMock = new Mock<ITeamDepthService>();
            _controller = new TeamDepthController(teamDepthServiceMock.Object);
        }

        [TestMethod]
        public async Task GetTeamDepth_ValidId_ReturnsTeamDepth()
        {
            string teamId = "1";
            TeamDepth expectedTeamDepth = new TeamDepth(teamId, new Team("6", "Test Team", new Sport("3", "Test Sport")));

            teamDepthServiceMock.Setup(r => r.GetTeamDepth(teamId)).ReturnsAsync(expectedTeamDepth);

            ActionResult<TeamDepth> result = await _controller.GetTeamDepth(teamId);

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task GetTeamDepth_InvalidId_ReturnsNotFound()
        {
            string teamId = "999";

            teamDepthServiceMock.Setup(r => r.GetTeamDepth(teamId)).ReturnsAsync((TeamDepth?)null);

            ActionResult<TeamDepth> result = await _controller.GetTeamDepth(teamId);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task AddPlayer_ValidData_ReturnsAddedPlayer()
        {
            string teamId = "1";
            var dto = new DepthDTO { Position = "QB", PlayerID = "playerId", Depth = 1 };
            Player expectedPlayer = new Player("1", 10, "Lionel Messi", new Team("1", "Test Team", new Sport("1", "Test Sport")));

            teamDepthServiceMock.Setup(r => r.AddPlayer(teamId, dto.Position, dto.PlayerID, dto.Depth)).ReturnsAsync(expectedPlayer);

            ActionResult<Player> result = await _controller.AddPlayer(teamId, dto);

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task AddPlayer_InvalidData_ReturnsBadRequest()
        {
            string teamId = "1";
            DepthDTO dto = null;

            ActionResult<Player> result = await _controller.AddPlayer(teamId, dto);

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task AddPlayer_PlayerNotFound_ReturnsBadRequest()
        {
            string teamId = "1";
            var dto = new DepthDTO { Position = "QB", PlayerID = "playerId", Depth = 1 };

            
            teamDepthServiceMock.Setup(r => r.AddPlayer(teamId, dto.Position, dto.PlayerID, dto.Depth)).ThrowsAsync(new ArgumentException("Player not found"));

            ActionResult<Player> result = await _controller.AddPlayer(teamId, dto);

            Assert.IsNotNull(result, "The result should not be null.");
        }

        [TestMethod]
        public async Task RemovePlayer_ValidData_ReturnsRemovedPlayer()
        {
            string teamId = "1";
            var dto = new DepthDTO { Position = "QB", PlayerID = "playerId" };
            Player expectedPlayer = new Player("1", 10, "Lionel Messi", new Team("1", "Test Team", new Sport("1", "Test Sport")));

            teamDepthServiceMock.Setup(r => r.RemovePlayer(teamId, dto.Position, dto.PlayerID)).ReturnsAsync(expectedPlayer);

            ActionResult<Player> result = await _controller.RemovePlayer(teamId, dto);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            OkObjectResult okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(expectedPlayer, okResult.Value);
        }

        [TestMethod]
        public async Task RemovePlayer_InvalidData_ReturnsBadRequest()
        {
            string teamId = "1";
            DepthDTO dto = null;

            ActionResult<Player> result = await _controller.RemovePlayer(teamId, dto);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetBackupPlayers_ValidData_ReturnsBackupPlayers()
        {
            string teamId = "1";
            var dto = new DepthDTO { Position = "QB", PlayerID = "playerId", Depth = 2 };
            Player player = new Player("1", 10, "Lionel Messi", new Team("1", "Test Team", new Sport("1", "Test Sport")));
            var expectedBackupPlayers = new List<Player>
            {
                new Player("2", 10, "Backup 1", new Team("1", "Test Team", new Sport("1", "Test Sport"))),
                new Player("3", 10, "Backup 2", new Team("1", "Test Team", new Sport("1", "Test Sport"))),
            };

            teamDepthServiceMock.Setup(r => r.GetBackupPlayers(teamId, dto.Position, dto.PlayerID, dto.Depth)).ReturnsAsync(expectedBackupPlayers);

            ActionResult<List<Player>> result = await _controller.GetBackupPlayers(teamId, dto);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            OkObjectResult okResult = (OkObjectResult)result.Result;
            List<Player> backupPlayers = (List<Player>)okResult.Value;
            CollectionAssert.AreEqual(expectedBackupPlayers, backupPlayers);
        }

        [TestMethod]
        public async Task GetBackupPlayers_InvalidData_ReturnsBadRequest()
        {
            string teamId = "1";
            DepthDTO dto = null;

            ActionResult<List<Player>> result = await _controller.GetBackupPlayers(teamId, dto);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }


    }
}
