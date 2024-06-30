using lemon_edge.Models;
using lemon_edge.Services.Validators;

namespace lemon_edge.Services.Maneuvers;
public abstract class BaseManeuver
{
    protected readonly IKeypad _keypad;
    protected readonly Maneuver _maneuver;
    protected readonly int _phoneNumberLength;
    protected readonly IEnumerable<IStartValidationRule>? _startValidationRules;
    protected readonly IEnumerable<IManeuverValidationRule>? _maneuverValidationRules;


    public BaseManeuver(
        IKeypad keypad,
        Maneuver maneuver,
        int phoneNumberLength,
        IEnumerable<IStartValidationRule>? startValidationRules = null,
        IEnumerable<IManeuverValidationRule>? maneuverValidationRules = null)
    {
        if (phoneNumberLength <= 0)
        {
            throw new ArgumentException("Phone number length must be greater than 0");
        }

        ArgumentNullException.ThrowIfNull(keypad);
        ArgumentNullException.ThrowIfNull(maneuver);


        _keypad = keypad;
        _maneuver = maneuver;
        _phoneNumberLength = phoneNumberLength;
        _startValidationRules = startValidationRules;
        _maneuverValidationRules = maneuverValidationRules;
    }

    /// <summary>
    /// Checks if the key is valid for the start.
    /// If no validation rules are provided, it will always return true.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected bool IsValidStart(char key)
    {
        if (_startValidationRules == null)
        {
            return true;
        }

        return _startValidationRules.All(x => x.IsValid(key));
    }

    /// <summary>
    /// Checks if the key is valid for the maneuver.
    /// If no validation rules are provided, it will always return true.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected bool IsValidManeuver(char key)
    {
        if (_maneuverValidationRules == null)
        {
            return true;
        }

        return _maneuverValidationRules.All(x => x.IsValid(key));
    }

    /// <summary>
    /// Calculates the total number of valid phone numbers that can be generated from the keypad.
    /// </summary>
    /// <returns></returns>
    public int CalculateTotalValidNumbers()
    {
        int count = 0;
        for (int i = 0; i < _keypad.Layout.GetLength(0); i++)
        {
            for (int j = 0; j < _keypad.Layout.GetLength(1); j++)
            {
                if (IsValidStart(_keypad.Layout[i, j]))
                {
                    count += CountPhoneNumbersFromPosition(i, j, 1);
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Counts the number of phone numbers that can be generated from the keypad starting from the given position.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    protected abstract int CountPhoneNumbersFromPosition(int row, int col, int length);
}
