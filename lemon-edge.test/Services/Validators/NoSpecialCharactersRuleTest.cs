using lemon_edge.Services.Validators;

namespace Tests;
[TestClass]
public class NoSpecialCharactersRuleTest
{
    [TestMethod]
    public void Should_Return_True_For_Valid_Keys()
    {
        var validator = new NoSpecialKeysRule();
        var keys = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        foreach (var number in keys)
        {
            Assert.IsTrue(validator.IsValid(number));
        }
    }

    [TestMethod]
    public void Should_Return_False_For_Invalid_Keys()
    {
        var validator = new NoSpecialKeysRule();
        var keys = new List<char> { '*', '#', };
        foreach (var number in keys)
        {
            Assert.IsFalse(validator.IsValid(number));
        }
    }
}