using lemon_edge.Models;
using lemon_edge.Services.Validators;

namespace lemon_edge.Services.Maneuvers;

public class QueenManeuver(IKeypad keypad, int phoneNumberLength, IEnumerable<IStartValidationRule>? startValidationRules = null, IEnumerable<IManeuverValidationRule>? maneuverValidationRules = null)
: BaseManeuver(keypad, maneuver, phoneNumberLength, startValidationRules, maneuverValidationRules)
{
    private static readonly Maneuver maneuver = new(ManeuverType.Queen, new List<Move> {
        new Move(0, 1),
        new Move(0, -1),
        new Move(1, 0),
        new Move(-1, 0),
        new Move(1, 1),
        new Move(1, -1),
        new Move(-1, 1),
        new Move(-1, -1)
    });

    protected override int CountPhoneNumbersFromPosition(int row, int col, int length)
    {
        if (row < 0 || row >= _keypad.RowCount || col < 0 || col >= _keypad.ColumnCount || !IsValidManeuver(_keypad.Layout[row, col]))
        {
            return 0;
        }

        if (length == _phoneNumberLength)
        {
            return 1;
        }

        int count = 0;

        foreach (var move in _maneuver.Moves)
        {
            int newRow = row + move.RowChange;
            int newCol = col + move.ColChange;

            while (newRow >= 0 && newRow < _keypad.RowCount && newCol >= 0 && newCol < _keypad.ColumnCount && IsValidManeuver(_keypad.Layout[newRow, newCol]))
            {
                count += CountPhoneNumbersFromPosition(newRow, newCol, length + 1);
                newRow += move.RowChange;
                newCol += move.ColChange;
            }
        }

        return count;
    }
}