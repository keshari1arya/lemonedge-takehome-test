namespace lemon_edge.Models;

public class Maneuver
{
    /// <summary>
    /// Gets the name of the maneuver.
    /// e.g. "Rook", "Bishop", "Queen", "Knight" etc.
    /// </summary>
    public string Name { get; private set; }
    public List<Move> Moves { get; private set; }

    public Maneuver(string name, List<Move> moves)
    {
        if (moves == null)
        {
            throw new ArgumentNullException(nameof(moves));
        }

        if (!ManeuverType.All().Contains(name))
        {
            throw new ArgumentException($"Maneuver type {name} is not supported");
        }

        if (moves.Count == 0)
        {
            throw new ArgumentException("Maneuver must have at least one move");
        }

        Name = name;
        Moves = moves;
    }
}