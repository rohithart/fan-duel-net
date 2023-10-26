using fanduel_net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fanduel_net.Tests
{
    [TestClass]
    public class SampleTests
    {

        [TestMethod]
        public void SampleTest()
        {
            var team = new Team("1", "Manchester United", new Sport("1", "Soccer"));
            var depth = new TeamDepth("1", team);
            var tom = new Player("1", 1, "Tom Brady", team);
            var blaine = new Player("2", 2, "Blaine Gabbert", team);
            var klye = new Player("3", 3, "Kyle Trask", team);
            var mike = new Player("4", 4, "Mike Evans", team);
            var jae = new Player("5", 5, "Jaelon Darden", team);
            var scott = new Player("6", 6, "Scott Miller", team);

            depth.AddPlayerToDepthChart("QB", tom, 1);
            depth.AddPlayerToDepthChart("QB", blaine, 2);
            depth.AddPlayerToDepthChart("QB", klye, 3);

            depth.AddPlayerToDepthChart("LWR", mike, 1);
            depth.AddPlayerToDepthChart("LWR", jae, 2);
            depth.AddPlayerToDepthChart("LWR", scott, 3);

            var backups = depth.GetBackups("QB", tom);

            Assert.AreEqual(2, backups.Count);
            Assert.AreEqual(blaine, backups[0]);
            Assert.AreEqual(klye, backups[1]);

            var backups2 = depth.GetBackups("LWR", jae);

            Assert.AreEqual(scott, backups2[0]);

            var backups3 = depth.GetBackups("QB", mike);

            Assert.AreEqual(0, backups3.Count);

            var backups4 = depth.GetBackups("QB", blaine);

            Assert.AreEqual(klye, backups4[0]);

            var backups5 = depth.GetBackups("QB", klye);

            Assert.AreEqual(0, backups5.Count);

            Assert.AreEqual(3, depth.DepthChart["QB"].Count);
            Assert.AreEqual(3, depth.DepthChart["LWR"].Count);

            var removedPlayer = depth.RemovePlayerFromDepthChart("LWR", mike);

            Assert.AreEqual(removedPlayer, mike);

            Assert.AreEqual(3, depth.DepthChart["QB"].Count);
            Assert.AreEqual(2, depth.DepthChart["LWR"].Count);
        }

    }
}

