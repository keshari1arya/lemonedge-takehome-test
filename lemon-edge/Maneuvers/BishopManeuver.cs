using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;

namespace lemon_edge.Maneuvers;
public class BishopManeuver : BaseManeuver
{
    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad, IEnumerable<IPositionValidationRule>? validationRules = null)
    {
        var possibleManueverPositions = new List<Position>();

        // for left top maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row - i, from.Column - i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for right top maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row - i, from.Column + i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for left bottom maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row + i, from.Column - i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        // for right bottom maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row + i, from.Column + i);
            ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);
        }

        return possibleManueverPositions;
    }
}
