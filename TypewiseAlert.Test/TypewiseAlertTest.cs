using Xunit;
namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimitsLow()
        {
            Assert.True(TypewiseAlert.InferBreach(12, 15, 30) == Constants.BreachType.Low);
        }
        [Fact]
        public void InfersBreachAsPerLimitsNormal()
        {
            Assert.True(TypewiseAlert.InferBreach(18, 15, 30) == Constants.BreachType.Normal);
        }
        [Fact]
        public void InfersBreachAsPerLimitsHigh()
        {
            Assert.True(TypewiseAlert.InferBreach(35, 15, 30) == Constants.BreachType.High);
        }
        [Fact]
        public void ClassifyTemperaturePassive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(Constants.CoolingType.PassiveCooling, -5) == Constants.BreachType.Low);
        }
        [Fact]
        public void ClassifyTemperatureMediumActive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(Constants.CoolingType.MediumActiveCooling, 10) == Constants.BreachType.Normal);
        }
        [Fact]
        public void ClassifyTemperatureHiActive()
        {
            Assert.True(TypewiseAlert.ClassifyTemperatureBreach(Constants.CoolingType.HiActiveCooling, 50) == Constants.BreachType.High);
        }

        [Fact]
        public void CheckAndAlertToEmailHighBreach()
        {
            Assert.True(TypewiseAlert.CheckAndAlert(Constants.AlertTarget.Email,
                new BatteryCharacter(Constants.CoolingType.PassiveCooling, "TCQ"), 50));
        }
        [Fact]
        public void CheckAndAlertToEmailLowBreach()
        {
            Assert.True(TypewiseAlert.CheckAndAlert(Constants.AlertTarget.Email,
                new BatteryCharacter(Constants.CoolingType.HiActiveCooling, "TCQ"), -2));
        }
        [Fact]
        public void CheckAndAlertToController()
        {
            Assert.True(TypewiseAlert.CheckAndAlert(Constants.AlertTarget.Controller,
                new BatteryCharacter(Constants.CoolingType.PassiveCooling, "TCQ"), 50));
        }
    }
}
