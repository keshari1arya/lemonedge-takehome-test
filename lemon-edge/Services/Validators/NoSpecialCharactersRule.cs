namespace lemon_edge.Services.Validators;

public class NoSpecialKeysRule : IManeuverValidationRule
{
    /// <summary>
    /// Checks if the key is valid for the maneuver.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsValid(char key)
    {
        return key != '*' && key != '#';
    }
}