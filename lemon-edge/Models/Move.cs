namespace lemon_edge.Models;
public class Move
{
    public int RowChange { get; private set; }
    public int ColChange { get; private set; }

    public Move(int rowChange, int colChange)
    {
        RowChange = rowChange;
        ColChange = colChange;
    }
}