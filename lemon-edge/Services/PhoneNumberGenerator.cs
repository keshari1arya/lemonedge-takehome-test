using lemon_edge.lib.Models;
using lemon_edge.lib.Validation;
using lemon_edge.Models;

namespace lemon_edge;
public class PhoneNumberGenerator(
    IKeypad _keypad,
    Maneuver maneuver,
    int phoneNumberLength,
    List<IValidationRule> _startValidationRules = null,
    List<IValidationRule> _maneuverValidationRules = null)
{
    private int numberCount = 0;
    public int CountValidPhoneNumbers()
    {
        for (int i = 0; i < _keypad.RowCount; i++)
        {
            for (int j = 0; j < _keypad.ColumnCount; j++)
            {
                var position = new Position(i, j);

                if (_startValidationRules?.All(x => x.IsValid(_keypad.GetKey(position))) == true)
                {
                    CalculatePhoneNumberCount(maneuver, position, 1);
                }
            }
        }

        return numberCount;
    }

    private void CalculatePhoneNumberCount(Maneuver maneuver, Position position, int startCount)
    {
        foreach (var rule in _maneuverValidationRules)
        {
            if (!rule.IsValid(_keypad.GetKey(position)))
            {
                return;
            }
        }

        if (startCount == phoneNumberLength)
        {
            numberCount++;
            return;
        }

        var possibleManueverPositions = maneuver.GetManueverablePositions(position, _keypad);

        foreach (var pos in possibleManueverPositions)
        {
            CalculatePhoneNumberCount(maneuver, pos, startCount + 1);
        }
    }
}