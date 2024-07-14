using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;
using lemon_edge.lib.Validation;

namespace lemon_edge;
public class PhoneNumberGenerator(
    IKeypad _keypad,
    BaseManeuver maneuver,
    int phoneNumberLength,
    IEnumerable<IPositionValidationRule>? _manueverPositionValidationRules = null,
    List<IValidationRule>? _startValidationRules = null,
    List<IValidationRule>? _maneuverValidationRules = null)
{
    private int numberCount = 0;
    public int CountValidPhoneNumbers()
    {
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

        return numberCount;
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

        if (startCount == phoneNumberLength)
        {
            numberCount++;
            return;
        }

        var possibleManueverPositions = maneuver.GetManueverablePositions(position, _keypad, _manueverPositionValidationRules);

        foreach (var pos in possibleManueverPositions)
        {
            DialAndCount(maneuver, pos, startCount + 1);
        }
    }
}