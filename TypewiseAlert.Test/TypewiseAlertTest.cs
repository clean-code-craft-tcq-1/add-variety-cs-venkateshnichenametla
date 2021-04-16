using Xunit;
namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimitsLow()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.InferBreach(12, 15, 30) == "Low");
        }
        [Fact]
        public void InfersBreachAsPerLimitsNormal()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.InferBreach(18, 15, 30) == "Normal");
        }
        [Fact]
        public void InfersBreachAsPerLimitsHigh()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.InferBreach(35, 15, 30) == "High");
        }
        [Fact]
        public void ClassifyTemperaturePassive()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.ClassifyTemperatureBreach("PassiveCooling", -5) == "Low");
        }
        [Fact]
        public void ClassifyTemperatureMediumActive()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.ClassifyTemperatureBreach("MediumActiveCooling", 10) == "Normal");
        }
        [Fact]
        public void ClassifyTemperatureHiActive()
        {
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            Assert.True(typewiseAlert.ClassifyTemperatureBreach("HiActiveCooling", 50) == "High");
        }
        [Fact]
        public void CheckFakeAlertPublish()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("HiActiveCooling", "Bosch");
            IAlert fakeAlert = new FakeAlert();
            TypewiseAlert typewiseAlert = new TypewiseAlert(fakeAlert);
            typewiseAlert.CheckAndAlert(batteryCharacter, 10);
            FakeAlert fakeAlerter = fakeAlert as FakeAlert;
            Assert.True(fakeAlerter.isCalledAtleastOnce);
        }
        [Fact]
        public void CheckAndAlertException()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("test", "abc");
            TypewiseAlert typewiseAlert = new TypewiseAlert();
            var ex = Record.Exception(() => typewiseAlert.CheckAndAlert(batteryCharacter, 10));
            Assert.NotNull(ex);
        }
    }
}
