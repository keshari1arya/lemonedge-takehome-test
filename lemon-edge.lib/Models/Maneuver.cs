namespace lemon_edge.lib.Models;

public abstract class Maneuver
{
    public abstract IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad);

    protected static bool IsValidPosition(IKeypad keypad, Position position)
    {
        if (position.Row < 0
            || position.Row >= keypad.RowCount
            || position.Column < 0
            || position.Column >= keypad.ColumnCount)
        {
            return false;
        }

        return true;
    }
}
