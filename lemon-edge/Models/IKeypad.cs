namespace lemon_edge.Models;
public interface IKeypad
{
    /// <summary>
    /// The layout of the keypad.
    /// </summary>
    char[,] Layout { get; }

    int RowCount { get; }
    int ColumnCount { get; }
}