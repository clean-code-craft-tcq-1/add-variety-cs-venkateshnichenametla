using Xunit;
namespace TypewiseAlert.Test
{
    public class TypeWiseAlertTest
    {
        [Fact]
        public void InfersBreachAsPerLimitsLow()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.InferBreach(12, 15, 30) == "Low");
        }
        [Fact]
        public void InfersBreachAsPerLimitsNormal()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.InferBreach(18, 15, 30) == "Normal");
        }
        [Fact]
        public void InfersBreachAsPerLimitsHigh()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.InferBreach(35, 15, 30) == "High");
        }
        [Fact]
        public void ClassifyTemperaturePassive()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.ClassifyTemperatureBreach("PassiveCooling", -5) == "Low");
        }
        [Fact]
        public void ClassifyTemperatureMediumActive()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.ClassifyTemperatureBreach("MediumActiveCooling", 10) == "Normal");
        }
        [Fact]
        public void ClassifyTemperatureHiActive()
        {
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            Assert.True(typeWiseAlert.ClassifyTemperatureBreach("HiActiveCooling", 50) == "High");
        }
        [Fact]
        public void CheckAndAlertOfFakeAlert()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("HiActiveCooling", "Bosch");
            IBreachObserver breachObserver = new FakeAlert();
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert(breachObserver);
            typeWiseAlert.CheckAndAlert(batteryCharacter, 10);
            FakeAlert fakeAlerter = breachObserver as FakeAlert;
            Assert.True(fakeAlerter.isCalledAtleastOnce);
        }

        [Fact]
        public void CheckAndAlertOfCompositeAlert()
        {
            IBreachObserver emailAlert = new EmailAlert();
            IBreachObserver consoleAlert = new ConsoleAlert();
            IBreachObserver controllerAlert = new ControllerAlert();
            CompositeAlert compositeAlert = new CompositeAlert();
            compositeAlert.AddBreachObserver(emailAlert);
            compositeAlert.AddBreachObserver(consoleAlert);
            compositeAlert.AddBreachObserver(controllerAlert);
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert(compositeAlert);
            BatteryCharacter batteryCharacter = new BatteryCharacter("HiActiveCooling", "Bosch");
            var exception = Record.Exception(() => typeWiseAlert.CheckAndAlert(batteryCharacter, 85));
            Assert.Null(exception);
        }
        [Fact]
        public void CheckAndAlertException()
        {
            BatteryCharacter batteryCharacter = new BatteryCharacter("test", "abc");
            TypeWiseAlert typeWiseAlert = new TypeWiseAlert();
            var ex = Record.Exception(() => typeWiseAlert.CheckAndAlert(batteryCharacter, 10));
            Assert.NotNull(ex);
        }
    }
}
