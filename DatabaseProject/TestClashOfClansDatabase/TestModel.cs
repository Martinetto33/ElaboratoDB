using DatabaseProject.config;
using DatabaseProject.model.code;

namespace TestClashOfClansDatabase
{
    [TestClass]
    public class TestModel
    {
        private static Builder CreateBuilder() => new("123", 1);
        private static Laboratory CreateLaboratory() => new("123", "123", "Lab", 1, 100, "This is the LABORATORY");
        private static Troop CreateTroop() => new("123", "Barbarian", 1, 100, 10.0, "This is a Barbarian");
        private static Defense CreateDefense() => new("building1", "123", "Cannon", 1, 100, 20.0, 1, 10);

        [TestMethod]
        public void TestEnumToString()
        {
            Assert.AreEqual("Special", BuildingType.Special.ToString());
        }

        [TestMethod]
        public async Task TestBuildingUpgrade()
        {
            var building = CreateDefense();
            int targetsNumber = building.TargetsNumber;
            int range = building.AttackRange;
            var builder = CreateBuilder();
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
            var building = CreateDefense();
            var builder = CreateBuilder();
            builder.UpgradeBuilding(building);
            Assert.IsTrue(builder.IsBusy);
            Assert.AreEqual(building, builder.UpgradingBuilding);
        }

        [TestMethod]
        public async Task TestTroopUpgrade()
        {
            Troop troop = CreateTroop();
            var lab = CreateLaboratory();
            await lab.UpgradeTroop(troop);
            Assert.AreEqual(2, troop.Level);
            Assert.AreEqual(15.0, troop.DamagePerSecond);
            Assert.AreEqual(110, troop.HealthPoints);
            Assert.IsTrue(lab.UpgradingTroop == null);
        }

        [TestMethod]
        public void TestTroopUpgradeWithoutAwaiting()
        {
            Laboratory laboratory = CreateLaboratory();
            var troop = CreateTroop();
            laboratory.UpgradeTroop(troop);
            Assert.IsTrue(laboratory.IsBusy);
            Assert.AreEqual(troop, laboratory.UpgradingTroop);
        }

        [TestMethod]
        public async Task TestMaxLevel()
        {
            Laboratory laboratory = CreateLaboratory();
            int level = Configuration.MAX_LEVEL;
            int health = 100;
            double damagePerSecond = 10.0;
            Troop troop = new("123", "Barbarian", level, health, damagePerSecond, "This is a Barbarian");
            await laboratory.UpgradeTroop(troop);
            Assert.AreEqual(Configuration.MAX_LEVEL, troop.Level);

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
            Laboratory laboratory = CreateLaboratory();
            laboratory.IsBusy = true;
            Troop troop = CreateTroop();
            Assert.ThrowsExceptionAsync<LaboratoryBusyException>(() => laboratory.UpgradeTroop(troop));

            var builder = CreateBuilder();
            builder.IsBusy = true;
            var defense = CreateDefense();
            Assert.ThrowsExceptionAsync<BuilderBusyException>(() => builder.UpgradeBuilding(defense));
        }

        [TestMethod]
        public void TestBuildingUpgradeTime()
        {
            var builder = CreateBuilder();
            var building = CreateDefense();
            var level = building.Level;
            builder.UpgradeBuilding(building);
            var upgradeTime = (long)(level * Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS * 1000);
            Assert.AreEqual(upgradeTime, builder.GetUpgradeTime());
            Assert.IsTrue(builder.GetRemainingUpgradeTime() < upgradeTime);
        }

        [TestMethod]
        public void TestTroopUpgradeTime()
        {
            var lab = CreateLaboratory();
            var troop = CreateTroop();
            var level = troop.Level;
            lab.UpgradeTroop(troop);
            var upgradeTime = (long)(level * Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS * 1000);
            Assert.AreEqual(upgradeTime, lab.GetUpgradeTime());
            Assert.IsTrue(lab.GetRemainingUpgradeTime() < upgradeTime);
        }
    }
}