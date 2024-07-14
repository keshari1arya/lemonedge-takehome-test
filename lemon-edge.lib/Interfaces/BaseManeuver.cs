using lemon_edge.lib.Models;
using lemon_edge.lib.Validation;

namespace lemon_edge.lib.Interfaces;

public abstract class BaseManeuver
{
    /// <summary>
    /// Gets the manueverable positions.
    /// </summary>
    /// <param name="from">Then position to start from.</param>
    /// <param name="validationRules">Add validation rules for the position. No need to add Position out of bounds of the board as it is checked by default.</param>
    /// <param name="validationRules"></param>
    /// <returns></returns>
    public abstract IEnumerable<Position> GetManueverablePositions(Position from, IKeypad keypad, IEnumerable<IPositionValidationRule>? validationRules = null);

    /// <summary>
    /// Validates the and add position to maneuverable positions.
    /// </summary>
    /// <param name="keypad">The keypad.</param>
    /// <param name="position">The position.</param>
    /// <param name="validationRules">Add validation rules for the position. No need to add Position out of bounds of the board as it is checked by default.</param>
    /// <returns></returns>
    protected static void ValidateAndAddPositionToManeuverablePositions(IKeypad keypad, Position position, IList<Position> positions, IEnumerable<IPositionValidationRule>? validationRules = null)
    {
        if (position.Row < 0
            || position.Row >= keypad.RowCount
            || position.Column < 0
            || position.Column >= keypad.ColumnCount)
        {
            return;
        }

        if (validationRules?.Any() == true)
        {
            foreach (var rule in validationRules)
            {
                if (!rule.IsValid(position, keypad))
                {
                    return;
                }
            }
        }

        positions.Add(position);
    }
}
