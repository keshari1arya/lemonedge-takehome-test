using lemon_edge.lib.Models;

namespace lemon_edge.Models;

public class StandardPhoneKeypad : IKeypad
{
    public char[,] Layout { get; private set; }
    public int RowCount { get; private set; }
    public int ColumnCount { get; private set; }

    public StandardPhoneKeypad()
    {
        // this can be loaded from database
        Layout = new char[4, 3]
        {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' },
                { '*', '0', '#' },
        };

        RowCount = Layout.GetLength(0);
        ColumnCount = Layout.GetLength(1);
    }

    public char GetKey(Position position)
    {
        return Layout[position.Row, position.Column];
    }
}