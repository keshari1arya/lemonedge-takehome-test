using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;

namespace lemon_edge;
/// <summary>
/// Generates valid phone numbers
/// </summary>
/// <param name="_keypad"></param>
/// <param name="_phoneNumberLength"></param>
/// <param name="_positionValidationRules"></param>
/// <param name="_startValidationRules"></param>
/// <param name="_maneuverValidationRules"></param>
public class PhoneNumberGenerator(
    IKeypad _keypad,
    int _phoneNumberLength,
    List<IValidationRule>? _startValidationRules = null,
    List<IValidationRule>? _maneuverValidationRules = null,
    IEnumerable<IPositionValidationRule>? _positionValidationRules = null)
{
    private int validPhoneNumberCount;

    public int CountValidPhoneNumbers(BaseManeuver maneuver)
    {
        validPhoneNumberCount = 0;
        for (int i = 0; i < _keypad.RowCount; i++)
        {
            for (int j = 0; j < _keypad.ColumnCount; j++)
            {
                var position = new Position(i, j);

                if (_startValidationRules != null && _startValidationRules.TrueForAll(x => x.IsValid(_keypad.GetKey(position))))
                {
                    DialAndCount(maneuver, position, 1);
                }
            }
        }

        return validPhoneNumberCount;
    }

    private void DialAndCount(BaseManeuver maneuver, Position position, int startCount)
    {
        if (_maneuverValidationRules?.Count > 0)
        {
            foreach (var rule in _maneuverValidationRules)
            {
                if (!rule.IsValid(_keypad.GetKey(position)))
                {
                    return;
                }
            }
        }

        if (startCount == _phoneNumberLength)
        {
            validPhoneNumberCount++;
            return;
        }

        var possibleManueverPositions = maneuver.GetManueverablePositions(position, _keypad, _positionValidationRules);

        foreach (var pos in possibleManueverPositions)
        {
            DialAndCount(maneuver, pos, startCount + 1);
        }
    }
}