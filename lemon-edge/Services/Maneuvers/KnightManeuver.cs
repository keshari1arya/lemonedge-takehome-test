using lemon_edge.Models;
using lemon_edge.Services.Validators;

namespace lemon_edge.Services.Maneuvers;

public class KnightManeuver(IKeypad keypad, int phoneNumberLength, IEnumerable<IStartValidationRule>? startValidationRules = null, IEnumerable<IManeuverValidationRule>? maneuverValidationRules = null)
: BaseManeuver(keypad, maneuver, phoneNumberLength, startValidationRules, maneuverValidationRules)
{
    private static readonly Maneuver maneuver = new(ManeuverType.Knight, new List<Move> {
        new Move(2, 1),
        new Move(2, -1),
        new Move(-2, 1),
        new Move(-2, -1),
        new Move(1, 2),
        new Move(1, -2),
        new Move(-1, 2),
        new Move(-1, -2)
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
            count += CountPhoneNumbersFromPosition(newRow, newCol, length + 1);
        }

        return count;
    }
}