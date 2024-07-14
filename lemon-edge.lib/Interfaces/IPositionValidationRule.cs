using lemon_edge.lib.Models;

namespace lemon_edge.lib.Interfaces;

public interface IPositionValidationRule
{

    bool IsValid(Position position, IKeypad keypad);
}

