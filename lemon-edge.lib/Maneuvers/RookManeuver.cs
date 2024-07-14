using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;

namespace lemon_edge.lib.Maneuvers;

public class RookManeuver : BaseManeuver
{
    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad, IEnumerable<IPositionValidationRule>? validationRules = null)
    {
        var possibleManueverPositions = new List<Position>();

        // for left maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row, from.Column - i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for right maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row, from.Column + i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for up maneuver
        for (int i = 1; i < keypad.RowCount; i++)
        {
            var position = new Position(from.Row - i, from.Column);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for down maneuver
        for (int i = 1; i < keypad.RowCount; i++)
        {
            var position = new Position(from.Row + i, from.Column);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        return possibleManueverPositions;
    }
}
