using Microsoft.VisualStudio.TestTools.UnitTesting;
using fanduel_net.Models;

namespace fanduel_net.Tests.Repositories
{
    [TestClass]
    public class TeamDepthTests
    {
        [TestMethod]
        public void AddPlayerToDepthChart_AddsPlayerToNewPosition()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player = new Player("1", 10, "Lionel Messi", team);

            depth.AddPlayerToDepthChart("QB", player);

            Assert.IsTrue(depth.DepthChart.ContainsKey("QB"));
            Assert.AreEqual(1, depth.DepthChart["QB"].Count);
            Assert.AreEqual(player, depth.DepthChart["QB"][0]);
        }

        [TestMethod]
        public void AddPlayerToDepthChart_AddsPlayerToFirstPosition()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2);

            Assert.AreEqual(2, depth.DepthChart["QB"].Count);
            Assert.AreEqual(player1, depth.DepthChart["QB"][0]);
            Assert.AreEqual(player2, depth.DepthChart["QB"][1]);
        }

        [TestMethod]
        public void AddPlayerToDepthChart_AddsPlayerAtSpecifiedDepth()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2, 1);

            Assert.AreEqual(2, depth.DepthChart["QB"].Count);
            Assert.AreEqual(player2, depth.DepthChart["QB"][0]);
            Assert.AreEqual(player1, depth.DepthChart["QB"][1]);
        }

        [TestMethod]
        public void AddPlayerToDepthChart_AddsPlayerAtUnboundDepth()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player1, 11);
            depth.AddPlayerToDepthChart("QB", player2, 20);

            Assert.AreEqual(2, depth.DepthChart["QB"].Count);
            Assert.AreEqual(player1, depth.DepthChart["QB"][0]);
            Assert.AreEqual(player2, depth.DepthChart["QB"][1]);
        }

        [TestMethod]
        public void RemovePlayerFromDepthChart_RemovesPlayer()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player = new Player("1", 10, "Lionel Messi", team);

            depth.AddPlayerToDepthChart("QB", player);
            var removedPlayer = depth.RemovePlayerFromDepthChart("QB", player);

            Assert.IsFalse(depth.DepthChart["QB"].Contains(player));
            Assert.AreEqual(player, removedPlayer);
        }

        [TestMethod]
        public void RemovePlayerFromDepthChart_ReturnsNullForInvalidPlayer()
        {;
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player = new Player("1", 10, "Lionel Messi", team);
            var invalidPlayer = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player);
            var removedPlayer = depth.RemovePlayerFromDepthChart("QB", invalidPlayer);

            Assert.IsNull(removedPlayer);
        }

        [TestMethod]
        public void RemovePlayerFromDepthChart_ReturnsNullForInvalidPosition()
        {
            ;
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player = new Player("1", 10, "Lionel Messi", team);

            depth.AddPlayerToDepthChart("QB", player);
            var removedPlayer = depth.RemovePlayerFromDepthChart("C", player);

            Assert.IsNull(removedPlayer);
        }

        [TestMethod]
        public void GetBackups_ReturnsCorrectBackups()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);
            var player3 = new Player("3", 12, "Other Player2", team);
            var player4 = new Player("4", 13, "Other Player3", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2);
            depth.AddPlayerToDepthChart("QB", player3);
            depth.AddPlayerToDepthChart("QB", player4);

            var backups = depth.GetBackups("QB", player2);

            Assert.AreEqual(2, backups.Count);
            Assert.AreEqual(player3, backups[0]);
            Assert.AreEqual(player4, backups[1]);
        }

        [TestMethod]
        public void GetBackups_ReturnsEmptyListForLastPlayer()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2);

            var backups = depth.GetBackups("QB", player2);

            Assert.AreEqual(0, backups.Count);
        }

        [TestMethod]
        public void GetBackups_ReturnsEmptyListForInvalidPlayer()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);
            var invalidPlayer = new Player("3", 99, "Other Player3", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2);

            var backups = depth.GetBackups("QB", invalidPlayer);

            Assert.AreEqual(0, backups.Count);
        }

        [TestMethod]
        public void GetBackups_ReturnsEmptyListForInvalidPosition()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var player1 = new Player("1", 10, "Lionel Messi", team);
            var player2 = new Player("2", 11, "Other Player", team);

            depth.AddPlayerToDepthChart("QB", player1);
            depth.AddPlayerToDepthChart("QB", player2);

            var backups = depth.GetBackups("C", player1);

            Assert.AreEqual(0, backups.Count);
        }
    }
}
