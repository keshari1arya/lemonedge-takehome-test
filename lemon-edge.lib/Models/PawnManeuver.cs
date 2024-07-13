namespace lemon_edge.lib.Models;

public class PawnManeuver : Maneuver
{
    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad)
    {
        var possibleManueverPositions = new List<Position>();
        var position = new Position(from.Row + 1, from.Column);
        if (IsValidPosition(keypad, position))
        {
            possibleManueverPositions.Add(position);
        }

        return possibleManueverPositions;
    }
}