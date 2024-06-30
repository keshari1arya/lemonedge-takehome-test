using lemon_edge.Models;
using lemon_edge.Services.Maneuvers;
using lemon_edge.Services.Validators;
public class PhoneNumberGenerator
{
    private readonly IKeypad _keypad;
    private readonly int _phoneNumberLength;
    private readonly IEnumerable<IStartValidationRule>? _startValidationRules;
    private readonly IEnumerable<IManeuverValidationRule>? _maneuverValidationRules;

    public PhoneNumberGenerator(IKeypad keypad, int phoneNumberLength)
    {
        _keypad = keypad;
        _phoneNumberLength = phoneNumberLength;

        _startValidationRules = new List<IStartValidationRule>(){
            new NoZeroOrOneStartRule()
        };

        _maneuverValidationRules = new List<IManeuverValidationRule>(){
            new NoSpecialKeysRule()
        };
    }

    public void GenerateAndPrintValidPhoneNumbers()
    {

        foreach (var maneuverName in ManeuverType.All())
        {
            BaseManeuver validator = CreateManeuver(maneuverName);
            int count = validator.CalculateTotalValidNumbers();
            Console.WriteLine($"{maneuverName}: {count} valid phone numbers");
        }
    }

    private BaseManeuver CreateManeuver(string name)
    {
        return name switch
        {
            ManeuverType.Rook => new RookManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules),
            ManeuverType.Bishop => new BishopManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules),
            ManeuverType.Queen => new QueenManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules),
            ManeuverType.Knight => new KnightManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules),
            _ => throw new NotSupportedException($"Validator for {name} is not implemented")
        };
    }
}