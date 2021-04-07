using Xunit;
namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimitsLow()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 15, 30) == "Low");
        }
        [Fact]
        public void InfersBreachAsPerLimitsNormal()
        {
            Assert.True(TypewiseAlert.InferBreach(18, 15, 30) == "Normal");
        }
        [Fact]
        public void InfersBreachAsPerLimitsHigh()
        {
            Assert.True(TypewiseAlert.InferBreach(35, 15, 30) == "High");
        }
        [Fact]
        public void ClassifyTemperaturePassive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach("PassiveCooling", -5) == "Low");
        }
        [Fact]
        public void ClassifyTemperatureMediumActive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach("MediumActiveCooling", 10) == "Normal");
        }
        [Fact]
        public void ClassifyTemperatureHiActive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach("HiActiveCooling", 50) == "High");
        }
        [Fact]
        public void CheckFakeAlertPublish()
        {
            FakeAlert fakeAlert = new FakeAlert();
            fakeAlert.PublishAlert("Low");
            Assert.True(fakeAlert.IsAlertPublished());
        }
        [Fact]
        public void CheckAndAlertException()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("test", "abc");
            var ex = Record.Exception(() => TypewiseAlert.CheckAndAlert("test", batteryCharacter, 10));
            Assert.NotNull(ex);
        }
    }
}
