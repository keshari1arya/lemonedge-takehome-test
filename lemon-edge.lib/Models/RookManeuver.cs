namespace lemon_edge.lib.Models;

public class RookManeuver : Maneuver
{
    public override IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad)
    {
        var possibleManueverPositions = new List<Position>();

        // for left maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row, from.Column - i);
            if (IsValidPosition(keypad, position))
            {
                possibleManueverPositions.Add(position);
            }
        }

        // for right maneuver
        for (int i = 1; i < keypad.ColumnCount; i++)
        {
            var position = new Position(from.Row, from.Column + i);
            if (IsValidPosition(keypad, position))
            {
                possibleManueverPositions.Add(position);
            }
        }

        // for up maneuver
        for (int i = 1; i < keypad.RowCount; i++)
        {
            var position = new Position(from.Row - i, from.Column);
            if (IsValidPosition(keypad, position))
            {
                possibleManueverPositions.Add(position);
            }
        }

        // for down maneuver
        for (int i = 1; i < keypad.RowCount; i++)
        {
            var position = new Position(from.Row + i, from.Column);
            if (IsValidPosition(keypad, position))
            {
                possibleManueverPositions.Add(position);
            }
        }

        return possibleManueverPositions;
    }
}
