// See https://aka.ms/new-console-template for more information
using lemon_edge;
using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Maneuvers;
using lemon_edge.lib.Models;
using lemon_edge.lib.Validation;
using lemon_edge.Maneuvers;
using lemon_edge.Models;


var keypad = new StandardPhoneKeypad();
var phoneNumberLength = 7;

var startValidators = new List<IValidationRule>
{
     new ValidStartKeyRule(['2','3','4','5','6','7','8','9']),
};

var maneuverValidators = new List<IValidationRule>
{
   new InvalidKeysRule(['#','*']),
};

var positionValidationRule = new List<IPositionValidationRule> { };


PhoneNumberGenerator generator = new(keypad, phoneNumberLength, startValidators, maneuverValidators);

var bishop = new BishopManeuver();
Console.WriteLine("Bishop: " + generator.CountValidPhoneNumbers(bishop));

var rook = new RookManeuver();
Console.WriteLine("Rook: " + generator.CountValidPhoneNumbers(rook));

var king = new KingManeuver();
Console.WriteLine("King: " + generator.CountValidPhoneNumbers(king));
