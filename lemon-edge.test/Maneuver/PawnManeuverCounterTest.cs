using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Maneuvers;
using lemon_edge.lib.Validation;
using lemon_edge.Models;

namespace lemon_edge.test;

[TestClass]
public class PawnManeuverCounterTest
{
    [TestMethod("Should count 3 valid phone numbers with standard phone keypad and validations and phone number length of 3")]
    public void Count()
    {
        // Arrange
        IKeypad keypad = new StandardPhoneKeypad();
        var _phoneNumberLength = 3;
        var _startValidationRules = new List<IValidationRule>
        {
            new ValidStartKeyRule(['2', '3', '4', '5', '6', '7', '8', '9'])
        };
        var _maneuverValidationRules = new List<IValidationRule>(){
            new InvalidKeysRule(['#', '*'])
        };
        var maneuver = new PawnManeuver();
        var generator = new PhoneNumberGenerator(keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);

        // Act
        var count = generator.CountValidPhoneNumbers(maneuver);

        // Assert
        Assert.AreEqual(3, count);
    }
    [TestMethod("Should count 4 valid phone numbers with standard phone keypad and validations and phone number length of 3 and start key is 1,2,3,4,5,6,7,8,9")]
    public void CountForStartKey()
    {
        // Arrange
        IKeypad keypad = new StandardPhoneKeypad();
        var _phoneNumberLength = 3;
        var _startValidationRules = new List<IValidationRule>
        {
            new ValidStartKeyRule(['1','2', '3', '4', '5', '6', '7', '8', '9'])
        };
        var _maneuverValidationRules = new List<IValidationRule>(){
            new InvalidKeysRule(['#', '*'])
        };
        var maneuver = new PawnManeuver();
        var generator = new PhoneNumberGenerator(keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);

        // Act
        var count = generator.CountValidPhoneNumbers(maneuver);

        // Assert
        Assert.AreEqual(4, count);
    }
}