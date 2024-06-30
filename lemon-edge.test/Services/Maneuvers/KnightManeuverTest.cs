// write test for bishop validator

using lemon_edge.Models;
using lemon_edge.Services.Maneuvers;
using lemon_edge.Services.Validators;

namespace Tests
{
    [TestClass]
    public class KnightManeuverTest
    {
        private readonly IStartValidationRule[] _startValidationRules = {
            new NoZeroOrOneStartRule()
        };

        private readonly IManeuverValidationRule[] _maneuverValidationRules = {
            new NoSpecialKeysRule()
        };
        [TestMethod]
        public void Should_Count_Phone_Numbers_From_Position()
        {
            // Arrange
            IKeypad _keypad = new StandardPhoneKeypad();
            var _phoneNumberLength = 7;
            var maneuver = new KnightManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);

            // Act
            int count = maneuver.CalculateTotalValidNumbers();

            // Assert
            Assert.AreEqual(952, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Argument_Exception_When_Phone_Number_Length_Is_Zero()
        {
            // Arrange
            IKeypad _keypad = new StandardPhoneKeypad();
            var _phoneNumberLength = 0;

            // Act
            var maneuver = new KnightManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_ArgumentNullException_When_Keypad_Is_Null()
        {
            // Arrange
            IKeypad? _keypad = null;
            var _phoneNumberLength = 7;

            // Act
#pragma warning disable CS8604 // Possible null reference argument.
            var maneuver = new KnightManeuver(_keypad, _phoneNumberLength);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }

}