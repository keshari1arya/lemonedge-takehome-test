using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Validation;
using lemon_edge.Maneuvers;
using lemon_edge.Models;

namespace lemon_edge.test;

[TestClass]
public class KingManeuverCounterTest
{
    [TestMethod("Should count 124908 valid phone numbers with standard phone keypad and validations")]
    public void Count()
    {
        // Arrange
        IKeypad keypad = new StandardPhoneKeypad();
        var _phoneNumberLength = 7;
        var _startValidationRules = new List<IValidationRule>
        {
            new ValidStartKeyRule(['2', '3', '4', '5', '6', '7', '8', '9'])
        };
        var _maneuverValidationRules = new List<IValidationRule>(){
            new InvalidKeysRule(['#', '*'])
        };
        var maneuver = new KingManeuver();
        var generator = new PhoneNumberGenerator(keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);

        // Act
        var count = generator.CountValidPhoneNumbers(maneuver);

        // Assert
        Assert.AreEqual(124908, count);
    }
}
