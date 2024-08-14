using DatabaseProject.config;
using DatabaseProject.model;

namespace TestClashOfClansDatabase
{
    [TestClass]
    public class TestModel
    {
        [TestMethod]
        public void TestEnumToString()
        {
            Assert.AreEqual("Special", BuildingType.Special.ToString());
        }

        [TestMethod]
        public async Task TestBuildingUpgrade()
        {
            var builder = new Builder("123", 1);
            int targetsNumber = 1;
            int range = 10;
            int level = 1;
            int health = 100;
            double damagePerSecond = 20.0;
            var building = new Defense("building1", "123", "Cannon", level, health, damagePerSecond, targetsNumber, range);
            await builder.UpgradeBuilding(building);
            Assert.AreEqual(2, building.Level);
            Assert.AreEqual(120.0, building.DamagePerSecond);
            Assert.IsTrue(building.TargetsNumber > targetsNumber || building.AttackRange > range);
            Assert.IsFalse(builder.IsBusy);
            Assert.IsTrue(builder.UpgradingBuilding == null);
        }

        [TestMethod]
        public void TestBuildingUpgradeWithoutAwait()
        {
            var builder = new Builder("123", 1);
            int targetsNumber = 1;
            int range = 10;
            int level = 1;
            int health = 100;
            double damagePerSecond = 20.0;
            var building = new Defense("building1", "123", "Cannon", level, health, damagePerSecond, targetsNumber, range);
            builder.UpgradeBuilding(building);
            Assert.IsTrue(builder.IsBusy);
            Assert.AreEqual(building, builder.UpgradingBuilding);
        }

        [TestMethod]
        public async Task TestTroopUpgrade()
        {
            Laboratory laboratory = new("123", "123", "Lab", 1, 100, "This is the laboratory");
            int level = 1;
            int health = 100;
            double damagePerSecond = 10.0;
            Troop troop = new("123", "Barbarian", level, health, damagePerSecond, "This is a Barbarian");
            await laboratory.UpgradeTroop(troop);
            Assert.AreEqual(2, troop.Level);
            Assert.AreEqual(15.0, troop.DamagePerSecond);
            Assert.AreEqual(110, troop.HealthPoints);
            Assert.IsTrue(laboratory.UpgradingTroop == null);
        }

        [TestMethod]
        public void TestTroopUpgradeWithoutAwaiting()
        {
            Laboratory laboratory = new("123", "123", "Lab", 1, 100, "This is the laboratory");
            int level = 1;
            int health = 100;
            double damagePerSecond = 10.0;
            Troop troop1 = new("123", "Barbarian", level, health, damagePerSecond, "This is a Barbarian");
            Troop troop2 = new("123", "Archer", 2, health, damagePerSecond, "This is an Archer");
            laboratory.UpgradeTroop(troop1);
            Assert.IsTrue(laboratory.IsBusy);
            Assert.AreEqual(troop1, laboratory.UpgradingTroop);
        }

        [TestMethod]
        public async Task TestMaxLevel()
        {
            Laboratory laboratory = new("123", "123", "Lab", 1, 100, "This is the laboratory");
            int level = Configuration.MAX_LEVEL;
            int health = 100;
            double damagePerSecond = 10.0;
            Troop troop1 = new("123", "Barbarian", level, health, damagePerSecond, "This is a Barbarian");
            await laboratory.UpgradeTroop(troop1);
            Assert.AreEqual(Configuration.MAX_LEVEL, troop1.Level);

            var builder = new Builder("123", 1);
            int targetsNumber = 1;
            int range = 10;
            int bLevel = Configuration.MAX_LEVEL;
            int bHealth = 100;
            double bDamagePerSecond = 20.0;
            var building = new Defense("building1", "123", "Cannon", bLevel, bHealth, bDamagePerSecond, targetsNumber, range);
            await builder.UpgradeBuilding(building);
            Assert.AreEqual(Configuration.MAX_LEVEL, building.Level);
        }

        [TestMethod]
        public void TestExceptions()
        {
            Laboratory laboratory = new("123", "123", "Lab", 1, 100, "This is the laboratory")
            {
                IsBusy = true
            };
            Troop troop = new("123", "Barbarian", 1, 100, 10.0, "This is a Barbarian");
            Assert.ThrowsExceptionAsync<LaboratoryBusyException>(() => laboratory.UpgradeTroop(troop));

            var builder = new Builder("123", 1)
            {
                IsBusy = true
            };
            int targetsNumber = 1;
            int range = 10;
            int level = 1;
            var defense = new Defense("building1", "123", "Cannon", level, 100, 20.0, targetsNumber, range);
            Assert.ThrowsExceptionAsync<BuilderBusyException>(() => builder.UpgradeBuilding(defense));
        }
    }
}