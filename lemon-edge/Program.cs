// See https://aka.ms/new-console-template for more information
using lemon_edge;
using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Maneuvers;
using lemon_edge.lib.Models;
using lemon_edge.lib.Validation;
using lemon_edge.Models;


var keypad = new StandardPhoneKeypad();
var rook = new RookManeuver();

var startValidators = new List<IValidationRule>
{
     new ValidStartKeyRule(['2','3','4','5','6','7','8','9']),
};

var maneuverValidators = new List<IValidationRule>
{
   new InvalidKeysRule(['#','*']),
};

var positionValidationRule = new List<IPositionValidationRule> { };

var phoneNumberLength = 7;

PhoneNumberGenerator generator = new(keypad, rook, phoneNumberLength, null, startValidators, maneuverValidators);

var count = generator.CountValidPhoneNumbers();

Console.WriteLine(count);