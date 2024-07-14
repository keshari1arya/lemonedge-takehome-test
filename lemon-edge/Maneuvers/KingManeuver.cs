using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;

namespace lemon_edge.Maneuvers;

public class KingManeuver : BaseManeuver
{

    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad, IEnumerable<IPositionValidationRule>? validationRules = null)
    {
        var possibleManueverPositions = new List<Position>();

        // for left maneuver
        var leftPosition = new Position(from.Row, from.Column - 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, leftPosition, possibleManueverPositions, validationRules);

        // for left top maneuver
        var leftTopPosition = new Position(from.Row - 1, from.Column - 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, leftTopPosition, possibleManueverPositions, validationRules);

        // for top maneuver
        var topPosition = new Position(from.Row - 1, from.Column);
        ValidateAndAddPositionToManeuverablePositions(keypad, topPosition, possibleManueverPositions, validationRules);

        // for right top maneuver
        var rightTopPosition = new Position(from.Row - 1, from.Column + 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, rightTopPosition, possibleManueverPositions, validationRules);

        // for right maneuver
        var rightPosition = new Position(from.Row, from.Column + 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, rightPosition, possibleManueverPositions, validationRules);

        // for right bottom maneuver
        var rightBottomPosition = new Position(from.Row + 1, from.Column + 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, rightBottomPosition, possibleManueverPositions, validationRules);

        // for bottom maneuver
        var bottomPosition = new Position(from.Row + 1, from.Column);
        ValidateAndAddPositionToManeuverablePositions(keypad, bottomPosition, possibleManueverPositions, validationRules);

        // for left bottom maneuver
        var leftBottomPosition = new Position(from.Row + 1, from.Column - 1);
        ValidateAndAddPositionToManeuverablePositions(keypad, leftBottomPosition, possibleManueverPositions, validationRules);

        return possibleManueverPositions;
    }
}