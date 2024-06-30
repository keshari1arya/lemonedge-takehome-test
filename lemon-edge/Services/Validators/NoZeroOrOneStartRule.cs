namespace lemon_edge.Services.Validators;

public class NoZeroOrOneStartRule : IStartValidationRule
{
    /// <summary>
    /// Checks if the key is valid for the start.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsValid(char key)
    {
        return key != '0' && key != '1';
    }
}
