// write test for bishop validator

using lemon_edge.Models;
using lemon_edge.Services.Maneuvers;
using lemon_edge.Services.Validators;

namespace Tests
{
    [TestClass]
    public class RookManeuverTest
    {
        private readonly IStartValidationRule[] _startValidationRules = {
            new NoZeroOrOneStartRule()
        };

        private readonly IManeuverValidationRule[] _maneuverValidationRules = {
            new NoSpecialKeysRule()
        };
        [TestMethod]
        public void CountPhoneNumbersFromPositionTest()
        {
            // Arrange
            IKeypad _keypad = new StandardPhoneKeypad();
            var _phoneNumberLength = 7;
            var maneuver = new RookManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);

            // Act
            int count = maneuver.CalculateTotalValidNumbers();

            // Assert
            Assert.AreEqual(49326, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Argument_Exception_When_Keypad_Is_Null()
        {
            // Arrange
            IKeypad _keypad = new StandardPhoneKeypad();
            var _phoneNumberLength = 0;

            // Act
            var maneuver = new RookManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);
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
            var maneuver = new RookManeuver(_keypad, _phoneNumberLength);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }

}