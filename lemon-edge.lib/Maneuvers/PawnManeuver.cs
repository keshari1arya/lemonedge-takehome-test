using lemon_edge.lib.Interfaces;
using lemon_edge.lib.Models;

namespace lemon_edge.lib.Maneuvers;

public class PawnManeuver : BaseManeuver
{
    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad, IEnumerable<IPositionValidationRule>? validationRules = null)
    {
        var possibleManueverPositions = new List<Position>();
        var position = new Position(from.Row + 1, from.Column);

        ValidateAndAddPositionToManeuverablePositions(keypad, position, possibleManueverPositions, validationRules);

        return possibleManueverPositions;
    }
}