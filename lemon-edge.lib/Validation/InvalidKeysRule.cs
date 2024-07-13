using lemon_edge.lib.Validation;

namespace lemon_edge.lib.Validation;

public class InvalidKeysRule(char[] invalidKeys) : IValidationRule
{
    /// <summary>
    /// Checks if the key is valid for the maneuver.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsValid(char key)
    {
        return !invalidKeys.Contains(key);
    }
}