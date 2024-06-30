namespace lemon_edge.Services.Validators;
public interface IValidationRule
{
    bool IsValid(char key);
}
public interface IStartValidationRule : IValidationRule
{

}

public interface IManeuverValidationRule : IValidationRule
{

}