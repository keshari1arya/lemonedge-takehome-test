using lemon_edge.lib.Validation;

namespace lemon_edge.lib.Validation;

public class ValidStartKeyRule(char[] validStartKeys) : IValidationRule
{
    /// <summary>
    /// Checks if the key is valid for the start.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsValid(char key)
    {
        return validStartKeys.Contains(key);
    }
}
